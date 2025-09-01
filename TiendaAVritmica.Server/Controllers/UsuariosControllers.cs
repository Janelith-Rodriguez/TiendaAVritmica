using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;
using TiendaAVritmica.Server.Repositorio;
using TiendaAVritmica.Shared.DTO;

namespace TiendaAVritmica.Server.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuariosController : ControllerBase
    {
        //private readonly Context context;
        private readonly IUsuarioRepositorio repositorio;
        private readonly IMapper mapper;

        public UsuariosController(IUsuarioRepositorio repositorio,
                                 IMapper mapper)
        {
            //this.context = context;
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await repositorio.Select();
            //return await context.Usuarios
            //                    .AsNoTracking()
            //                    .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            Usuario? u = await repositorio.SelectById(id);
            if (u == null)
            {
                return NotFound();
            }
            return u;
            //Usuario? U = await context.Usuarios
            //              .FirstOrDefaultAsync(x => x.Id == id);

            //if (U == null)
            //{
            //    return NotFound();
            //}

            //return U;
        }

        [HttpGet("existe/{id:int}")] //api/Titulos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearUsuarioDTO entidadDTO)
        {
            try
            {
                Usuario entidad = mapper.Map<Usuario>(entidadDTO);

                return await repositorio.Insert(entidad);
                //Usuario entidad = new Usuario();
                //entidad.Nombre = entidadDTO.Nombre;
                //entidad.Apellido = entidadDTO.Apellido;
                //entidad.Email = entidadDTO.Email;
                //entidad.Contrasena = entidadDTO.Contrasena;
                //entidad.Telefono = entidadDTO.Telefono;
                //entidad.Direccion = entidadDTO.Direccion;
                //entidad.TipoUsuario = entidadDTO.TipoUsuario;

                //Usuario entidad = mapper.Map<Usuario>(entidadDTO);
                //context.Usuarios.Add(entidad);
                //await context.SaveChangesAsync();
                //return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Usuario entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var u = await repositorio.SelectById(id);

            if (u == null)
            {
                return NotFound("No existe el usuario buscado.");
            }

            u.Nombre = entidad.Nombre;
            u.Email = entidad.Email;
            u.Activo = entidad.Activo;

            try
            {
                await repositorio.Update(id, u);
                return Ok();
                //context.Usuarios.Update(u);
                //await context.SaveChangesAsync();
                //return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El tipo de documento {id} no existe.");
            }
            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            //var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
            //if (!existe) return NotFound($"El usuario {id} no existe.");

            //var entidad = new Usuario { Id = id };
            //context.Remove(entidad);
            //await context.SaveChangesAsync();
            //return Ok();
        }
    }
}
