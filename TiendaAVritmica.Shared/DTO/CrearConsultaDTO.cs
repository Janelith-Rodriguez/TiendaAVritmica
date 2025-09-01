using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAVritmica.Shared.DTO
{
    public class CrearConsultaDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El mensaje es obligatorio")]
        [MaxLength(500, ErrorMessage = "Máximo {1} caracteres.")]
        public string Mensaje { get; set; }

        [Required(ErrorMessage = "La fecha de envio es obligatorio")]
        //[MaxLength(150, ErrorMessage = "Máximo {1} caracteres.")]
        public DateTime FechaEnvio { get; set; }
    }
}
