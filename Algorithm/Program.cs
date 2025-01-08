using Algorithm.Cryptography.CryptographyAlgorithm.Historicals;
using Algorithm.Models;
using Microsoft.OpenApi.Models;
using static Algorithm.Cryptography.CryptographyAlgorithm.Historicals.AtbashCipher;
using static Algorithm.Cryptography.CryptographyAlgorithm.Historicals.CeaserCipher;
using static Algorithm.Cryptography.CryptographyAlgorithm.Historicals.VigenereCipher;

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

//app.MapPost("/ecc-encrypt", (EncryptRequest request) =>
//{
//    var curve = new EllipticCurve();

//    // Anahtar çifti oluþtur
//    var (publicKey, privateKey) = curve.GenerateKeyPair();

//    // Þifrelenecek mesajý bir eðri noktasý olarak temsil et
//    var message = new Point(123456789, 987654321);

//    // Mesajý þifrele
//    var (C1, C2) = curve.Encrypt(message, publicKey);

//    // Þifreyi çöz
//    var decryptedMessage = curve.Decrypt(C1, C2, privateKey);
//});

app.MapPost("/1", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/2", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/3", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/4", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/5", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/6", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/7", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/8", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/9", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/10", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/11", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/12", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/13", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/14", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/15", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/16", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/17", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/18", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/19", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/20", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/21", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/22", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/23", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/24", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/25", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/26", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/27", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/28", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/29", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});
app.MapPost("/30", (DecryptRequest request) =>
{
    var decryptedText = VigenereDecrypt(request.Ciphertext);
    return Results.Ok(new { DecryptedText = decryptedText });
});



app.Run();

