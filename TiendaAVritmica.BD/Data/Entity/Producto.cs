using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAVritmica.BD.Data.Entity
{
    [Index(nameof(CategoriaId), nameof(Nombre), Name = "Producto_UQ", IsUnique = true)] //Indice FK
    [Index(nameof(Precio), nameof(Descripcion), Name = "Producto_Precio_Descripcion", IsUnique = false)] 

    public class Producto : EntityBase
    {
        [Required(ErrorMessage = "El nombre del producto es obligatoria")]
        [MaxLength(150, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción del producto es obligatoria")]
        [MaxLength(200, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatoria")]
        [MaxLength(15, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock del producto es obligatoria")]
        [MaxLength(15, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La imagen url del producto es obligatoria")]
        [MaxLength(10, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string ImagenUrl { get; set; }

        [Required(ErrorMessage = "La categoria es obligatoria")]
        public int CategoriaId { get; set; } // Clave foránea
        public Categoria Categoria { get; set; }
    }
}
