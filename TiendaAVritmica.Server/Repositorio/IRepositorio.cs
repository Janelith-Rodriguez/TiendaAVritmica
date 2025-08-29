using TiendaAVritmica.BD.Data;

namespace TiendaAVritmica.Server.Repositorio
{
    public interface IRepositorio<E> where E : class, IEntityBase
    {
        Task<bool> Delete(int id);
        Task<int> Insert(E entidad);
        Task<List<E>> Select();
        Task<E> SelectById(int id);
        Task<bool> Update(int id, E entidad);
    }
}