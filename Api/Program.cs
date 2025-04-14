using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SmartTransit.Application.DependencyInjection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Configurações JWT
var jwtSettings = builder.Configuration.GetSection("Settings:Jwt");
var secretKey = jwtSettings["SigningKey"];  // A chave de assinatura

if (string.IsNullOrEmpty(secretKey))
{
    throw new ArgumentNullException("SigningKey", "JWT SigningKey não está configurada.");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = jwtSettings["Issuer"],     // Usando o Issuer configurado
            ValidAudience = jwtSettings["Audience"], // Usando o Audience configurado
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,   // Validando a chave de assinatura
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey)  // Usando a chave de assinatura configurada
            ),
            ClockSkew = TimeSpan.Zero
        };
    });

// 2️⃣ Autorização
builder.Services.AddAuthorization();

// 3️⃣ Injeção de Dependência da sua aplicação
builder.Services.AddDependencyInjection(builder.Configuration);

// 4️⃣ Swagger com autenticação JWT no header
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT no header usando o esquema Bearer.  
                        Exemplo: 'Bearer eyJhbGci...'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// 5️⃣ Controllers
builder.Services.AddControllers();

// 6️⃣ Monta o app
var app = builder.Build();

// 7️⃣ Middlewares
app.UseHttpsRedirection();

app.UseAuthentication(); // 🔐 Primeiro autentica
app.UseAuthorization();  // 🔓 Depois autoriza

// 8️⃣ Swagger
app.UseSwagger();
app.UseSwaggerUI();

// 9️⃣ Mapeia rotas
app.MapControllers();

// 🔟 Starta o app
app.Run();
