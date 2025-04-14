using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SmartTransit.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos serviços e DI da camada Application
builder.Services.AddDependencyInjection(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Mapeamento dos controllers
app.MapControllers();

// Inicia a aplicação
app.Run();