using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        Task<List<Categoria>> BuscarPorNombre(string nombre);
    }
}
