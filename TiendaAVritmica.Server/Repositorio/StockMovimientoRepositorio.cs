using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public class StockMovimientoRepositorio : Repositorio<StockMovimiento>, IStockMovimientoRepositorio
    {
        private readonly Context context;

        public StockMovimientoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
