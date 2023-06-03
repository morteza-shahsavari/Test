using Quiz.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigureServices()
    .ConfigurePipline();
await app.ResetDataBaseAsync();
app.Run();
