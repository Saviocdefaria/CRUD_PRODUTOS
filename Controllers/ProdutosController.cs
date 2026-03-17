using CRUD_PRODUTOS.Data;
using CRUD_PRODUTOS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_PRODUTOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)     // Configuração da controller
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>>
         Get()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get(int id) 
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Produto produto) 
        {
            var produtoExistente = _context.Produtos.Find(id);
            if (produtoExistente == null)
            {
                return NotFound();
            }
            produtoExistente.Nome = produto.Nome;
            produtoExistente.Preco_Compra = produto.Preco_Compra;
            produtoExistente.Preco_Revenda = produto.Preco_Revenda;

            _context.SaveChanges();
            return Ok(produtoExistente);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            var produtoExistente = _context.Produtos.Find(id);
            if (produtoExistente == null) 
            {
                return NotFound();
            }
            _context.Produtos.Remove(produtoExistente);
            _context.SaveChanges();
            return NoContent();
        }
        }

    }


