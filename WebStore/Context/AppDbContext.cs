using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
}