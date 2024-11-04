using BlogCore.Models;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository;

public interface ICategoryRepository : IRepository<Categoria>
{
    void Update (Categoria category);

    //IEnumerable<SelectLis> GetCategoryList ();
}
