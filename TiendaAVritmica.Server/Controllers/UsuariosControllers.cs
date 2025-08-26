using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;
using TiendaAVritmica.Shared.DTO;

namespace TiendaAVritmica.Server.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly Context context;

        public UsuariosController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await context.Usuarios.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario == null) return NotFound();
            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearUsuarioDTO entidadDTO)
        {
            try
            {
                Usuario entidad = new Usuario();
                entidad.Nombre = entidadDTO.Nombre;
                entidad.Apellido = entidadDTO.Apellido;
                entidad.Email = entidadDTO.Email;
                entidad.Contrasena = entidadDTO.Contrasena;
                entidad.Telefono = entidadDTO.Telefono;
                entidad.Direccion = entidadDTO.Direccion;
                entidad.TipoUsuario = entidadDTO.TipoUsuario;

                context.Usuarios.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Usuario entidad)
        {
            if (id != entidad.Id) return BadRequest("Datos incorrectos");

            var usuario = await context.Usuarios.FirstOrDefaultAsync(e => e.Id == id);
            if (usuario == null) return NotFound("No existe el usuario buscado.");

            usuario.Nombre = entidad.Nombre;
            usuario.Email = entidad.Email;
            usuario.Activo = entidad.Activo;

            try
            {
                context.Usuarios.Update(usuario);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
            if (!existe) return NotFound($"El usuario {id} no existe.");

            var entidad = new Usuario { Id = id };
            context.Remove(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
