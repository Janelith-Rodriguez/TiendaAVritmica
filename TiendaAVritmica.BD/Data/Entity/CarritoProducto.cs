using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAVritmica.BD.Data.Entity
{
    [Index(nameof(Cantidad), Name = "CarritoProducto_UQ", IsUnique = true)]
    public class CarritoProducto : EntityBase
    {
        [Required(ErrorMessage = "El carrito es obligatoria")]
        // FK
        public int CarritoId { get; set; }
        public Carrito Carrito { get; set; }

        [Required(ErrorMessage = "El producto es obligatoria")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatoria")]
        public decimal PrecioUnitario { get; set; }
    }
}
