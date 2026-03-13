namespace CRUD_PRODUTOS.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome {get; set; }
        public int Qte_Estoque { get; set; }
        public decimal Preco_Compra { get; set; }
        public decimal Preco_Revenda { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }  // Navigation Property
    }
}
