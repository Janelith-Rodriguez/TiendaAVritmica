using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public interface ICompraRepositorio : IRepositorio<Compra>
    {
        Task<List<Compra>> ObtenerPorUsuario(int usuarioId);
    }
}
