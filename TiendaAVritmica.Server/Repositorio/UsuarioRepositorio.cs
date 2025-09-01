using Microsoft.EntityFrameworkCore;
using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        private readonly Context context;

        public UsuarioRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
        public async Task<Usuario> BuscarPorEmail(string email)
        {
            return await context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
