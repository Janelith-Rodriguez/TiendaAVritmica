using Microsoft.EntityFrameworkCore;
using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly Context context;

        public CategoriaRepositorio( Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Categoria>> BuscarPorNombre(string nombre)
        {
            return await context.Categorias
                .Where(c => c.Nombre.Contains(nombre))
                .ToListAsync();
        }
    }
}
