using Microsoft.EntityFrameworkCore;
using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public class CompraRepositorio : Repositorio<Compra>, ICompraRepositorio
    {
        private readonly Context context;

        public CompraRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Compra>> ObtenerPorUsuario(int usuarioId)
        {
            return await context.Compras
                .Where(c => c.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
