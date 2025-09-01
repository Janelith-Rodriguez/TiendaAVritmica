using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAVritmica.Shared.DTO
{
    public class CrearCarritoDTO
    {
        [Required(ErrorMessage = "La fecha  de creación es obligatoria")]
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "La fecha  de confirmación es obligatoria")]
        public DateTime FechaConfirmacion { get; set; }

        [Required(ErrorMessage = "El estado de pago es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres.")]
        public string EstadoPago { get; set; }

        [Required(ErrorMessage = "El monto total es obligatorio")]
        //[Precision(18, 2)] // 18 dígitos, 2 decimales
        public decimal MontoTotal { get; set; }

        [Required(ErrorMessage = "El saldo es obligatorio")]
        //[Precision(18, 2)] // 18 dígitos, 2 decimales
        public decimal Saldo { get; set; }

        [Required(ErrorMessage = "La dirección de envio es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres.")]
        public string DireccionEnvio { get; set; }
    }
}
