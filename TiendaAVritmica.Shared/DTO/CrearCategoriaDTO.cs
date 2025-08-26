using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAVritmica.Shared.DTO
{
    public class CrearCategoriaDTO
    {
        [Required(ErrorMessage = "El nombre de la categoria es obligatoria")]
        [MaxLength(150, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción de la categoria es obligatoria")]
        [MaxLength(200, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Descripcion { get; set; }
    }
}
