using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAVritmica.BD.Data.Entity
{
    [Index(nameof(Email), Name = "Usuario_UQ", IsUnique = true)]
    public class Usuario : EntityBase
    {
        [Required(ErrorMessage = "El nombre del usuario es obligatorio")]
        [MaxLength(200, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del usuario es obligatorio")]
        [MaxLength(200, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El email del usuario es obligatorio")]
        [MaxLength(200, ErrorMessage = "Maximo numero de caracteres{1}.")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña del usuario es obligatorio")]
        [MaxLength(255, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "El teléfono del usuario es obligatorio")]
        [MaxLength(20, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El dirección del usuario es obligatorio")]
        [MaxLength(250, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El tipo de usuario es obligatorio")]
        public string TipoUsuario { get; set; }

        // Relación: un usuario puede tener muchas compras
        public List<Compra> Compras { get; set; }
        //public List<Carrito> Carritos { get; set; }
        //public List<Consulta> Consultas { get; set; }
    }
}
