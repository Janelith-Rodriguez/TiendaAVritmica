using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public class CarritoProductoRepositorio : Repositorio<CarritoProducto>, ICarritoProductoRepositorio
    {
        private readonly Context context;

        public CarritoProductoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
