// Data/ProdutoContext.cs
using Microsoft.EntityFrameworkCore;
using ProdutoApi.Models;


namespace ProdutoApi.Data;

public class ProdutoContext : DbContext
{
    public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
}
