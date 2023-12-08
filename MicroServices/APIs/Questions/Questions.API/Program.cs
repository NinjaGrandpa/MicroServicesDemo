using FastEndpoints;
using Questions.DataAccess;

// Uses Builder Pattern

var builder = WebApplication.CreateBuilder(args);

// Register Services
builder.Services.AddEndpointsApiExplorer(); // Maps the endpoint classes
builder.Services.AddFastEndpoints();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>(); // Uses Strategy Pattern for Dependency Injection
builder.Services.AddHttpClient("openTriviaDb", c => c.BaseAddress = new Uri("https://opentdb.com/"));

var app = builder.Build();

// Middleware pipeline
app.UseHttpsRedirection(); // Redirects http calls to https
app.UseRouting(); // Sets up more advanced routes - can be used with swagger to use the API without a client.

app.UseFastEndpoints();

app.Run();
