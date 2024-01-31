using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

// Krypteringsfunktion med Leet Speak
string LeetSpeak(string text)
{
    text = text.Replace("e", "3");
    text = text.Replace("o", "0");
    text = text.Replace("l", "1");
    text = text.Replace("t", "7");
    text = text.Replace("a", "4");
    return text;
}

// Endpoint för att kryptera
app.MapPost("/encrypt", async (HttpContext context) =>
{
    using var reader = new System.IO.StreamReader(context.Request.Body);
    var requestBody = await reader.ReadToEndAsync();
    var encryptedText = LeetSpeak(requestBody);

    await context.Response.WriteAsync($"Encrypted Text: {encryptedText}");
});

// Endpoint för att avkryptera
app.MapPost("/decrypt", async (HttpContext context) =>
{
    using var reader = new System.IO.StreamReader(context.Request.Body);
    var requestBody = await reader.ReadToEndAsync();
    var decryptedText = LeetSpeak(requestBody);

    await context.Response.WriteAsync($"Decrypted Text: {decryptedText}");
});

app.Run();
