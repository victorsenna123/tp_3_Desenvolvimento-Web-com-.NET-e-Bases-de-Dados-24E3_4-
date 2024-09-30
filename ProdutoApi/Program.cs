using Microsoft.EntityFrameworkCore;
using ProdutoApi.Data;
using ProdutoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext com o SQLite
builder.Services.AddDbContext<ProdutoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ProdutoConnection")));

var app = builder.Build();

// Cria o banco de dados ao iniciar a aplicação (para fins de exemplo)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProdutoContext>();
    dbContext.Database.EnsureCreated();
}

// Endpoints CRUD para os produtos

// Listar todos os produtos
app.MapGet("/produtos", async (ProdutoContext db) => await db.Produtos.ToListAsync());

// Buscar um produto por ID
app.MapGet("/produtos/{id}", async (int id, ProdutoContext db) =>
    await db.Produtos.FindAsync(id) is Produto produto
        ? Results.Ok(produto)
        : Results.NotFound());

// Adicionar um novo produto
app.MapPost("/produtos", async (Produto produto, ProdutoContext db) =>
{
    db.Produtos.Add(produto);
    await db.SaveChangesAsync();
    return Results.Created($"/produtos/{produto.Id}", produto);
});

// Editar um produto
app.MapPut("/produtos/{id}", async (int id, Produto produtoAtualizado, ProdutoContext db) =>
{
    var produto = await db.Produtos.FindAsync(id);
    if (produto is null) return Results.NotFound();

    produto.Nome = produtoAtualizado.Nome;
    produto.Preco = produtoAtualizado.Preco;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Excluir um produto
app.MapDelete("/produtos/{id}", async (int id, ProdutoContext db) =>
{
    var produto = await db.Produtos.FindAsync(id);
    if (produto is null) return Results.NotFound();

    db.Produtos.Remove(produto);
    await db.SaveChangesAsync();
    return Results.Ok(produto);
});

app.Run();
