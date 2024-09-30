using Microsoft.EntityFrameworkCore;
using RelacionamentoApi.Data;
using RelacionamentoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext com o SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Cria o banco de dados ao iniciar a aplicação (para fins de exemplo)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

// Endpoints CRUD para Pessoa e Passaporte

// Criar uma nova pessoa
app.MapPost("/pessoas", async (Pessoa pessoa, ApplicationDbContext db) =>
{
    db.Pessoas.Add(pessoa);
    await db.SaveChangesAsync();
    return Results.Created($"/pessoas/{pessoa.Id}", pessoa);
});

// Criar um novo passaporte e associá-lo a uma pessoa
app.MapPost("/passaportes", async (Passaporte passaporte, ApplicationDbContext db) =>
{
    var pessoa = await db.Pessoas.FindAsync(passaporte.PessoaId);
    if (pessoa is null) return Results.NotFound("Pessoa não encontrada");

    db.Passaportes.Add(passaporte);
    await db.SaveChangesAsync();
    return Results.Created($"/passaportes/{passaporte.Id}", passaporte);
});


// Listar todas as pessoas com seus respectivos passaportes
app.MapGet("/pessoas", async (ApplicationDbContext db) =>
    await db.Pessoas.Include(p => p.Passaporte).ToListAsync());

app.Run();
