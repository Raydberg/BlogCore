namespace BlogCore.AccesoDatos.Data.Repository.IRepository;

public interface IContainerWork : IDisposable
{
    //TODO: Se agregaran todo los repositorios
    ICategoryRepository Category { get; }


    void Save ();

}
