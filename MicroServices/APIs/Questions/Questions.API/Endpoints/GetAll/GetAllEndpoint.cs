using Domain.Common.DTOs;
using FastEndpoints;
using Questions.DataAccess;

namespace Questions.API.Endpoints.GetAll;

public class GetAllEndpoint(IQuestionRepository repository) : Endpoint<GetAllRequest, GetAllResponse>
{
    public override void Configure()
    {
        Get("/api/question/get-all");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetAllRequest req, CancellationToken ct)
    {
        var questions = await repository.GetAllAsync();
        var questionDtos = questions.Select(q => new QuestionDto(
            q.Type, 
            q.Difficulty, 
            q.Category, 
            q.QuestionText, 
            q.CorrectAnswer, 
            q.IncorrectAnswers
            ));


        await SendAsync(new()
        {
            Questions = questionDtos
        });
    }
}
