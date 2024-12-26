using Cryptography.App.Models;
using Cryptography.App.Services.Historicals;
using Microsoft.OpenApi.Models;
using static Cryptography.App.Services.Historicals.AtbashCipher;
using static Cryptography.App.Services.Historicals.CeaserCipher;
using static Cryptography.App.Services.Historicals.VigenereCipher;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minimal API", Version = "v1" });
});
builder.Services.AddOpenApi();
builder.Services.AddScoped<HillCipher>();
var app = builder.Build();

// Swagger UI'yi etkinleþtirin  
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API V1");
    c.RoutePrefix = string.Empty; // Swagger UI'yi kök dizinde açmak için  
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.MapPost("/atbash", (EncryptRequest request) =>
{
    return Results.Ok(AtbashEncryptAndDecrypt(request.Plaintext));
});

app.MapPost("/ceaser-encrypt", (EncryptRequest request) =>
{
    var encryptedText = CeaserEncrypt(request.Plaintext);
    return Results.Ok(new { EncryptedText = encryptedText });
});

app.MapPost("/ceaser-decrypt", (DecryptRequest request) =>
{
    var decryptedText = CeaserDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});

app.MapPost("/hill-encrypt", (EncryptRequest request, HillCipher _hillCipher) =>
{

    return Results.Ok(_hillCipher.HillEncrypt(request.Plaintext));
});

app.MapPost("/hill-decrypt", (DecryptRequest request, HillCipher _hillCipher) =>
{
    var hillCipher = new HillCipher();
    return Results.Ok(_hillCipher.HillDecrypt(request.Ciphertext));
});
app.MapPost("/vigenere-encrypt", (EncryptRequest request) =>
{
    var encryptedText = VigenereEncrypt(request.Plaintext);
    return Results.Ok(new { EncryptedText = encryptedText });
});

app.MapPost("/vigenere-decrypt", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.Run();

