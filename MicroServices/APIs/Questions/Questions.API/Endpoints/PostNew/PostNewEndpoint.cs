using FastEndpoints;
using Questions.DataAccess;

namespace Questions.API.Endpoints.PostNew;

public class PostNewEndpoint(IQuestionRepository repository) : Endpoint<PostNewRequest, PostNewResponse>
{
    public override void Configure()
    {
        Post("/api/question/new");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PostNewRequest req, CancellationToken ct)
    {
        await repository.AddAsync(new Question
        {
            Category = req.NewQuestion.Category,
            QuestionText = req.NewQuestion.QuestionText,
            IncorrectAnswers = req.NewQuestion.IncorrectAnswers,
            Type = req.NewQuestion.Type,
            Difficulty = req.NewQuestion.Difficulty,
            CorrectAnswer = req.NewQuestion.CorrectAnswer,
        });

        await SendAsync(new()
        {

        }, cancellation: ct);
    }
}
