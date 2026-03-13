namespace CRUD_PRODUTOS.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        List<Produto> Produtos {get; set; } = new List<Produto>();
    }
}
