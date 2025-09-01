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
    [Route("api/Consultas")]
    public class ConsultasControllers : ControllerBase
    {
        //private readonly Context context;
        private readonly IConsultaRepositorio repositorio;
        private readonly IMapper mapper;

        public ConsultasControllers(IConsultaRepositorio repositorio,
                                     IMapper mapper)
        {
            //this.context = context;
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        // GET: api/Consultas
        [HttpGet]
        public async Task<ActionResult<List<Consulta>>> Get()
        {
            return await repositorio.Select();
            //return await context.Consultas
            //                     .AsNoTracking()
            //                     .ToListAsync();
        }

        // GET: api/Consultas/2
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Consulta>> Get(int id)
        {
            Consulta? Con= await repositorio.SelectById(id);
            //Consulta? Con = await context.Consultas
            //              .FirstOrDefaultAsync(x => x.Id == id);

            if (Con == null)
            {
                return NotFound();
            }

            return Con;
        }

        [HttpGet("existe/{id:int}")] //api/Consultas/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        // POST: api/Consultas
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearConsultaDTO entidadDTO)
        {
            try
            {
                //Consulta entidad = new Consulta();
                //entidad.Nombre = entidadDTO.Nombre;
                //entidad.Email = entidadDTO.Email;
                //entidad.Mensaje = entidadDTO.Mensaje;
                //entidad.FechaEnvio = entidadDTO.FechaEnvio;

                Consulta entidad = mapper.Map<Consulta>(entidadDTO);
                return await repositorio.Insert(entidad);
                //context.Consultas.Add(entidad);
                //await context.SaveChangesAsync();
                //return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);

            }
        }

        // PUT: api/Consultas/2
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Consulta entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrrectos");
            }
            var Con = await repositorio.SelectById(id);
            //var Con = await context.Consultas
            //              .Where(e => e.Id == id)
            //              .FirstOrDefaultAsync();

            if (Con == null)
            {
                return NotFound("No existe la consulta buscada.");
            }

            Con.UsuarioId = entidad.UsuarioId;
            Con.Nombre = entidad.Nombre;
            Con.Email = entidad.Email;
            Con.Mensaje = entidad.Mensaje;
            Con.FechaEnvio = entidad.FechaEnvio;
            Con.Activo = entidad.Activo;

            try
            {
                await repositorio.Update(id, Con);
                return Ok();

                //context.Consultas.Update(Con);
                //await context.SaveChangesAsync();
                //return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Consultas/2
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
           // var existe = await context.Consultas.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La consulta {id} no existe.");
            }

            //Consulta EntidadABorrar = new Consulta();
            //EntidadABorrar.Id = id;

            //context.Remove(EntidadABorrar);
            //await context.SaveChangesAsync();
            //return Ok();
            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
