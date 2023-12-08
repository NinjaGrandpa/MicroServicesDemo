using Domain.Common.DTOs;
using FastEndpoints;
using Questions.DataAccess;

namespace Questions.API.Endpoints.GetQuestionsForQuiz;

public class GetQuestionsForQuizEndpoint(IQuestionRepository repository) : Endpoint<GetQuestionsForQuizRequest, GetQuestionsForQuizResponse>
{
    public override void Configure()
    {
        Get("/api/question/get-for-quiz");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetQuestionsForQuizRequest req, CancellationToken ct)
    {
        var questions = await repository.GetQuestionsForQuizAsync(req.Ids, ct);
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
