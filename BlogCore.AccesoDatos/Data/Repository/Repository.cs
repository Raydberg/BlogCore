using BlogCore.AccesoDatos.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogCore.AccesoDatos.Data.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext Context;
    internal DbSet<T> dbSet;

    public Repository (DbContext context)
    {
        Context = context;
        dbSet = context.Set<T>();
    }


    public void Add (T entity) { dbSet.Add(entity); }

    public T Get (int id) { return dbSet.Find(id); }


    public IEnumerable<T> GetAll (Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
        , string includeProperties = null)
    {
        //Se crea una consulta IQueryable a partir del dbSet del conetxto
        IQueryable<T> query = dbSet;
        //Se aplica filtro si se proporciona
        if (filter != null) query = query.Where(filter);
        //Se incluye propiedades de navegacion si se proporcionan
        if (includeProperties != null)
            //Se divide la cadena de propiedades por coma y se itera sobre ellas
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);
        //Se aplica el ordenamiento se si proporciona
        if (orderBy != null) return orderBy(query).ToList();
        return query.ToList();
    }

    public T GetFirstOrDefault (Expression<Func<T, bool>>? filter = null, string includeProperties = null)
    {
        //Se crea una consulta IQueryable a partir del dbSet del conetxto
        IQueryable<T> query = dbSet;
        //Se aplica filtro si se proporciona
        if (filter != null) query = query.Where(filter);
        // Se incluye propiedades de navegacion si se proporcionan
        if (includeProperties != null)
            //Se divide la cadena de propiedades por coma y se itera sobre ellas
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

        return query.FirstOrDefault();
    }

    public void Remove (int id)
    {
        T entityToRemove = dbSet.Find(id);
        if (entityToRemove != null)
        {
            dbSet.Remove(entityToRemove);
        }

    }

    public void Remove (T entity)
    {
        dbSet.Remove(entity);
    }
}
