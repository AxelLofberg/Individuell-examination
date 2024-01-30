var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!!!");

app.MapGet("/hej", () => "Hej jag mår inte bra!");

app.Run();
