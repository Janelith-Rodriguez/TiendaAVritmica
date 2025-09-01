using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        Task<List<Producto>> ObtenerPorCategoria(int categoriaId);
    }
}
