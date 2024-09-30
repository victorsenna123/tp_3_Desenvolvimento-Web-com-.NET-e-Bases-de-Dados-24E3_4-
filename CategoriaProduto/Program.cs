using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar o serviço do banco de dados em memória e adicionar controladores
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("AppDb"));
builder.Services.AddControllers();

var app = builder.Build();

// Mapear rotas dos controladores
app.MapControllers();

app.Run();
