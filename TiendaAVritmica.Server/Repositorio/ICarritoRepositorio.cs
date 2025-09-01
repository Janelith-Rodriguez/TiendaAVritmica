using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public interface ICarritoRepositorio : IRepositorio<Carrito>
    {
        Task<Carrito> ObtenerPorUsuario(int usuarioId);
    }
}
