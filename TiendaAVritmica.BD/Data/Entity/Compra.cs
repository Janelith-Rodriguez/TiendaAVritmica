using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAVritmica.BD.Data.Entity
{
    [Index(nameof(UsuarioId), nameof(Fecha), Name = "Compra_UQ", IsUnique = true)]
    public class Compra : EntityBase
    {
        // FK con Usuario
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "La fecha de la compra es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La descripción de la compra es obligatoria")]
        public string Descripcion { get; set; }

        // Relación con CompraDetalle
        public List<CompraDetalle> CompraDetalles { get; set; }
    }
}
