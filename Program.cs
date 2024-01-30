var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!!!");

app.MapGet("/hej", () => "Hej jag mår bra!");

app.Run();
