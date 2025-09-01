using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAVritmica.Shared.DTO
{
    public class CrearStockMovimientoDTO
    {
        [Required(ErrorMessage = "El tipo de movimiento es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres.")]
        public string TipoMovimiento { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [MaxLength(500, ErrorMessage = "Máximo {1} caracteres.")]
        public string Descripcion { get; set; }
    }
}
