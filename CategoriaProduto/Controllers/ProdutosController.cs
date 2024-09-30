using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriarProduto(Produto produto)
        {
            // Verificar se a Categoria existe
            var categoria = _context.Categorias.Find(produto.CategoriaId);

            if (categoria == null)
            {
                return NotFound(new { message = "Categoria não encontrada" });
            }

            // Associar a categoria ao produto
            produto.Categoria = categoria;

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpGet]
        public IActionResult ListarProdutos()
        {
            var produtos = _context.Produtos.Include(p => p.Categoria).ToList();
            return Ok(produtos);
        }
    }
}
