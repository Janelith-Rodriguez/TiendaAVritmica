using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio( Context context) : base(context)
        {
            
        }
    }
}
