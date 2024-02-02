using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

// Krypteringsfunktion med Rövarspråk
string ToRovarsprak(string text)
{
    char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y', 'å', 'ä', 'ö', 'A', 'E', 'I', 'O', 'U', 'Y', 'Å', 'Ä', 'Ö' };
    var result = new System.Text.StringBuilder();

    foreach (char c in text)
    {
        result.Append(c);

        if (Array.IndexOf(vowels, c) != -1)
        {
            result.Append('o');
            result.Append(char.ToLower(c));
        }
    }

    return result.ToString();
}

app.MapPost("/encrypt", async (HttpContext context) =>
{
    using var reader = new StreamReader(context.Request.Body);
    var requestBody = await reader.ReadToEndAsync();
    var encryptedText = ToRovarsprak(requestBody);

    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync(encryptedText);
});

// Kommentera ut eller ta bort detta block för att inte hantera "/"
/*
app.MapGet("/", async (HttpContext context) =>
{
    var htmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "index.html");
    var htmlContent = await File.ReadAllTextAsync(htmlFilePath);
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(htmlContent);
});
*/

app.Run();
