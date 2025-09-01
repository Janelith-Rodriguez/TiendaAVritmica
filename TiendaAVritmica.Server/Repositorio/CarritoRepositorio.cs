using Microsoft.EntityFrameworkCore;
using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public class CarritoRepositorio : Repositorio<Carrito>, ICarritoRepositorio
    {
        private readonly Context context;

        public CarritoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Carrito> ObtenerPorUsuario(int usuarioId)
        {
            return await context.Carritos
                .FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);
        }
    }
}
