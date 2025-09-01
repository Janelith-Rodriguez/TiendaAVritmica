using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAVritmica.BD.Data.Entity
{
    [Index(nameof(CategoriaId), nameof(Nombre), Name = "Producto_UQ", IsUnique = true)] // Índice único por Categoría + Nombre
    [Index(nameof(Precio), Name = "Producto_Precio", IsUnique = false)] // Índice en Precio

    public class Producto : EntityBase
    {
        [Required(ErrorMessage = "El nombre del producto es obligatoria")]
        [MaxLength(150, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }

        //[Required(ErrorMessage = "La descripción del producto es obligatoria")]
        [MaxLength(200, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        //[Precision(18, 2)] // 18 dígitos, 2 decimales
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock del producto es obligatoria")]
        //[MaxLength(15, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La imagen url del producto es obligatoria")]
        [MaxLength(250, ErrorMessage = "Máximo {1} caracteres.")]
        public string ImagenUrl { get; set; }

        // FK
        [Required(ErrorMessage = "La categoria es obligatoria")]
        public int CategoriaId { get; set; } 
        public Categoria Categoria { get; set; }

        // Relaciones
        public List<CarritoProducto> CarritoProductos { get; set; }
        public List<StockMovimiento> StockMovimientos { get; set; }
        public List<CompraDetalle> CompraDetalles { get; set; }
    }
}
