using Domain.Common.DTOs;
using FastEndpoints;
using Questions.DataAccess;

namespace Questions.API.Endpoints.GetQuestionsFromCategory;

public class GetQuestionsFromCategoryEndpoint(IQuestionRepository repository) : Endpoint<GetQuestionsFromCategoryRequest, GetQuestionsFromCategoryResponse>
{
    public override void Configure()
    {
        Get("/api/question/get-from-question");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetQuestionsFromCategoryRequest req, CancellationToken ct)
    {
        var questions = await repository.GetForCategoryAsync(req.Category, req.Amount, ct);

        await SendAsync(new()
        {
            Questions = questions.Select(q => new QuestionDto(
                q.Type,
                q.Difficulty,
                q.Category,
                q.QuestionText,
                q.CorrectAnswer,
                q.IncorrectAnswers
            )).ToList()
        }, cancellation: ct);
    }
}
