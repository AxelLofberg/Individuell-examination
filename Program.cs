var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!!!");

app.MapGet("//", () => "Hej jag mår bra!");

app.Run();
