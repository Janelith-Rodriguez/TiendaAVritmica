using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAVritmica.Shared.DTO
{
    public class CrearCompraDetalleDTO
    {
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio de compra es obligatorio")]
        public decimal PrecioCompra { get; set; }

        [Required(ErrorMessage = "El precio de venta actualizado es obligatorio")]
        public decimal PrecioVentaActualizado { get; set; }
    }
}
