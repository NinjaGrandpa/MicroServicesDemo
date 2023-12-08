using Amazon.Util;
using Domain.Common.DTOs;
using FastEndpoints;
using Questions.DataAccess;

namespace Questions.API.Endpoints.GetQuestionsWithDifficulty;

public class GetQuestionsWithDifficultyEndpoint(IQuestionRepository repository) : Endpoint<GetQuestionsWithDifficultyRequest, GetQuestionsWithDifficultyResponse>
{
    public override void Configure()
    {
        Get("/api/question/get-from-difficulty");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetQuestionsWithDifficultyRequest req, CancellationToken ct)
    {
        var questions = await repository.GetQuestionsForDifficultyAsync(req.Difficulty, req.Amount, ct);

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
