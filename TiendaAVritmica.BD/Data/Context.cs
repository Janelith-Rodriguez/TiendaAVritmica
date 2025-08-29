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
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<CarritoProducto> CarritoProductos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraDetalle> CompraDetalles { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<StockMovimiento> StockMovimientos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                         .SelectMany(t => t.GetForeignKeys())
                                         .Where(fk => !fk.IsOwnership
                                                      && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            //// Opcional: definir precisión de Precio
            //modelBuilder.Entity<Producto>()
            //    .Property(p => p.Precio)
            //    .HasPrecision(18, 2);

            //modelBuilder.Entity<CompraDetalle>()
            //    .Property(d => d.PrecioCompra)
            //    .HasPrecision(18, 2);

            //// ======================
            //// USUARIOS
            //// ======================
            //modelBuilder.Entity<Usuario>()
            //    .HasIndex(u => u.Email)
            //    .IsUnique(); // cada usuario tiene un email único

            //// ======================
            //// PRODUCTOS
            //// ======================
            //modelBuilder.Entity<Producto>()
            //    .HasIndex(p => p.CategoriaId); // FK categoría

            //modelBuilder.Entity<Producto>()
            //    .HasIndex(p => p.Nombre); // búsqueda por nombre de producto

            //// ======================
            //// COMPRAS
            //// ======================
            //modelBuilder.Entity<Compra>()
            //    .HasIndex(c => c.UsuarioId); // FK usuario

            //modelBuilder.Entity<Compra>()
            //    .HasIndex(c => c.Fecha); // búsquedas por fecha

            //// ======================
            //// COMPRA DETALLE
            //// ======================
            //modelBuilder.Entity<CompraDetalle>()
            //    .HasIndex(cd => cd.CompraId);

            //modelBuilder.Entity<CompraDetalle>()
            //    .HasIndex(cd => cd.ProductoId);

            //// ======================
            //// CARRITO
            //// ======================
            //modelBuilder.Entity<Carrito>()
            //    .HasIndex(c => c.UsuarioId);

            //modelBuilder.Entity<Carrito>()
            //    .HasIndex(c => c.Estado);

            //modelBuilder.Entity<Carrito>()
            //    .HasIndex(c => c.EstadoPago);

            //// ======================
            //// CARRITO PRODUCTOS
            //// ======================
            //modelBuilder.Entity<CarritoProducto>()
            //    .HasIndex(cp => cp.CarritoId);

            //modelBuilder.Entity<CarritoProducto>()
            //    .HasIndex(cp => cp.ProductoId);

            //// ======================
            //// CONSULTAS
            //// ======================
            //modelBuilder.Entity<Consulta>()
            //    .HasIndex(co => co.UsuarioId);

            //modelBuilder.Entity<Consulta>()
            //    .HasIndex(co => co.Email);

            //// ======================
            //// PAGOS
            //// ======================
            //modelBuilder.Entity<Pago>()
            //    .HasIndex(p => p.CarritoId);

            //modelBuilder.Entity<Pago>()
            //    .HasIndex(p => p.EstadoPago);

            //// ======================
            //// STOCK MOVIMIENTOS
            //// ======================
            //modelBuilder.Entity<StockMovimiento>()
            //    .HasIndex(sm => sm.ProductoId);

            //modelBuilder.Entity<StockMovimiento>()
            //    .HasIndex(sm => sm.TipoMovimiento);
        }
    }
}
