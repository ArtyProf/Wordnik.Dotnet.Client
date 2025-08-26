using Wordnik.Dotnet.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<WordnikClient>(client =>
{
    client.BaseAddress = new Uri("https://api.wordnik.com/v4");
});

builder.Services.AddSingleton(provider =>
{
    return new WordnikClient(provider.GetRequiredService<HttpClient>(), "YOUR_API_KEY");
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
