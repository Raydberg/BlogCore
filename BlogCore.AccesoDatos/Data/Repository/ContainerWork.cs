using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;

namespace BlogCore.AccesoDatos.Data.Repository;

public class ContainerWork : IContainerWork
{
    private readonly ApplicationDbContext _db;

    public ContainerWork (ApplicationDbContext db)
    {
        _db = db;
        Category = new CategoryRepository(_db);
    }

    public ICategoryRepository Category { get; }

    public void Dispose () { _db.Dispose(); }

    public void Save () { _db.SaveChanges(); }
}


