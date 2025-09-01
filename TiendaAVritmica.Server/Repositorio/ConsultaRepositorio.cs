using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Repositorio
{
    public class ConsultaRepositorio : Repositorio<Consulta>, IConsultaRepositorio
    {
        private readonly Context context;

        public ConsultaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
