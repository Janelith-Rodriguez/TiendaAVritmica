using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAVritmica.Shared.DTO
{
    public class CrearProductoDTO
    {
        [Required(ErrorMessage = "El nombre del producto es obligatoria")]
        [MaxLength(150, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción del producto es obligatoria")]
        [MaxLength(200, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Descripcion { get; set; }

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
        //[Required(ErrorMessage = "La categoria es obligatoria")]
        //public int CategoriaId { get; set; }
        //public Categoria Categoria { get; set; }
    }
}
