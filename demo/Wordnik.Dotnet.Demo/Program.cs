using Wordnik.Dotnet.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IWordnikClient, WordnikClient>((_, httpClient) =>
{
    httpClient.BaseAddress = new Uri("https://api.wordnik.com/v4/");
    httpClient.DefaultRequestHeaders.Add("api_key", "your-api-key");
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
