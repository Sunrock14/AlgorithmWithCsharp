using Cryptography.App.Services;
using Microsoft.AspNetCore.Mvc;
using static Cryptography.App.Services.CeaserCipher;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapPost("/ceaser-encrypt", (EncryptRequest request) =>
{
    var encryptedText = Encrypt(request.Plaintext);
    return Results.Ok(new { EncryptedText = encryptedText });
});

app.MapPost("/ceaser-decrypt", (DecryptRequest request) =>
{
    var decryptedText = Decrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});

app.MapPost("/hill-encrypt", (EncryptRequest request) =>
{
    var hillCipher = new HillCipher();

    return Results.Ok(hillCipher.Encrypt(request.Plaintext));
});

app.MapPost("/hill-decrypt", (DecryptRequest request) =>
{
    var hillCipher = new HillCipher();
    return Results.Ok(hillCipher.Decrypt(request.Ciphertext));
});
app.Run();



public class EncryptRequest
{
    public string Plaintext { get; set; }
}

public class DecryptRequest
{
    public string Ciphertext { get; set; }
}