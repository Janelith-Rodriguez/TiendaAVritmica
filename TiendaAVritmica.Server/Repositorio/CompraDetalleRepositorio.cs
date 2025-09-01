using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public class CompraDetalleRepositorio : Repositorio<CompraDetalle>, ICompraDetalleRepositorio
    {
        private readonly Context context;

        public CompraDetalleRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
