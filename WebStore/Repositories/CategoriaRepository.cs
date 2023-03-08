using WebStore.Context;
using WebStore.Models;
using WebStore.Repositories.Interfaces;

namespace WebStore.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _context ;

    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Categoria> Categorias => _context.Categorias;
}