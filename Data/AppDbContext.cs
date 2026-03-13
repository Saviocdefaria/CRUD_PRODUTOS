using CRUD_PRODUTOS.Models;
using Microsoft.EntityFrameworkCore;


namespace CRUD_PRODUTOS.Data
{
    public class AppDbContext : DbContext   // Herança
    {
        public DbSet<Produto> Produtos { get; set; }             //propriedades DbSet
        public DbSet<Categoria> Categorias { get; set; }
       
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }// Construtor que recebe as configurações do banco e envia para a classe DbContext
    
    }
}

