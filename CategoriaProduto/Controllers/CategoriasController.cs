using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriarCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }

        [HttpGet]
        public IActionResult ListarCategorias()
        {
            var categorias = _context.Categorias.Include(c => c.Produtos).ToList();
            return Ok(categorias);
        }
    }
}
