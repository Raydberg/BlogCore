using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;

namespace BlogCore.AccesoDatos.Data.Repository;

public class CategoryRepository : Repository<Categoria>, ICategoryRepository
{
    private readonly ApplicationDbContext _db;

    public CategoryRepository (ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update (Categoria category)
    {
        var objFromDb = _db.Categorias.FirstOrDefault(s => s.Id == category.Id);
        if (objFromDb != null)
        {
            objFromDb.Nombre = category.Nombre;
            objFromDb.Orden = category.Orden;
        }

        _db.SaveChanges();
    }
}
