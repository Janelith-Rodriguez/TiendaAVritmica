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
    [Route("api/Compras")]
    public class ComprasController : ControllerBase
    {
        //private readonly Context context;
        private readonly ICompraRepositorio repositorio;
        private readonly IMapper mapper;

        public ComprasController(ICompraRepositorio repositorio,
                                 IMapper mapper)

        {
            //this.context = context;
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Compra>>> Get()
        {
            return await repositorio.Select();
            //return await context.Compras
            //                    .Include(c => c.Usuario)
            //                    .AsNoTracking()
            //                    .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Compra>> Get(int id)
        {
            Compra? com = await repositorio.SelectById(id);
            //var com = await context.Compras
            //                          .Include(c => c.Usuario)
            //                          .FirstOrDefaultAsync(x => x.Id == id);
            if (com == null)
            {
                return NotFound();
            }
            return com;
        }

        [HttpGet("existe/{id:int}")] //api/Compras/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearCompraDTO entidadDTO)
        {
            try
            {
                //Compra entidad = new Compra();
                //entidad.Fecha = entidadDTO.Fecha;
                //entidad.Descripcion = entidadDTO.Descripcion;

                Compra entidad = mapper.Map<Compra>(entidadDTO);
                return await repositorio.Insert(entidad);

                //context.Compras.Add(entidad);
                //await context.SaveChangesAsync();
                //return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Compra entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var com = await repositorio.SelectById(id);
            //var com = await context.Compras
            //                 .FirstOrDefaultAsync(e => e.Id == id);

            if (com == null)
            {
                return NotFound("No existe la compra buscada.");
            }

            com.UsuarioId = entidad.UsuarioId;
            com.Fecha = entidad.Fecha;
            com.Descripcion = entidad.Descripcion;

            try
            {
                await repositorio.Update(id, com);
                return Ok();

                //context.Compras.Update(c);
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
            //var existe = await context.Compras.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La compra {id} no existe.");
            }

            //Compra EntidadABorrar = new Compra();
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
