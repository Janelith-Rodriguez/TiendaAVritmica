using Microsoft.EntityFrameworkCore;
using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly Context context;

        public ProductoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Producto>> ObtenerPorCategoria(int categoriaId)
        {
            return await context.Productos
                .Where(p => p.CategoriaId == categoriaId)
                .ToListAsync();
        }
    }
}
