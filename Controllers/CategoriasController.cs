using Microsoft.AspNetCore.Mvc;
using CRUD_PRODUTOS.Data;  // preencher os using das clas
using CRUD_PRODUTOS.Models;

namespace CRUD_PRODUTOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>>
            Get()
        {
            var categoria = _context.Categorias.ToList();
            return Ok(categoria);
        }

        [HttpGet("{id}")]
        public ActionResult GetAction(int id) 
        {
            var result = _context.Categorias.Find(id);
            if (result == null) 
            {
              return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria) 
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Categoria categoria, int id) 
        {
            var categoriaExistente = _context.Categorias.Find(id);
            if (categoriaExistente == null) 
            {
                return NotFound();
            }
            categoriaExistente.Nome = categoria.Nome;
            _context.SaveChanges();
            return Ok(categoriaExistente);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            var categoriaExistente = _context.Categorias.Find(id);
            if (categoriaExistente == null)
            {
               return NotFound();
            }
            _context.Remove(categoriaExistente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
