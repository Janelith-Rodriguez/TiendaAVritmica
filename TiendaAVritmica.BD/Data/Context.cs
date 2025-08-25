using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.BD.Data
{
    public class Context : DbContext
    {
        //Tablas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        
        
        
        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
