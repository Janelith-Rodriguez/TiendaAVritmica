using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAVritmica.Shared.DTO
{
    public class CrearCompraDTO
    {
        [Required(ErrorMessage = "La fecha de la compra es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La descripción de la compra es obligatoria")]
        public string Descripcion { get; set; }
    }
}
