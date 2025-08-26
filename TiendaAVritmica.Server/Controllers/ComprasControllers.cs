using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;
using TiendaAVritmica.Shared.DTO;

namespace TiendaAVritmica.Server.Controllers
{
    [ApiController]
    [Route("api/Compras")]
    public class ComprasController : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public ComprasController(Context context,
                                 IMapper mapper)

        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Compra>>> Get()
        {
            return await context.Compras
                                .Include(c => c.Usuario)
                                .AsNoTracking()
                                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Compra>> Get(int id)
        {
            var compra = await context.Compras
                                      .Include(c => c.Usuario)
                                      .FirstOrDefaultAsync(x => x.Id == id);
            if (compra == null) return NotFound();
            return compra;
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
                context.Compras.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Compra entidad)
        {
            if (id != entidad.Id) return BadRequest("Datos incorrectos");

            var compra = await context.Compras.FirstOrDefaultAsync(e => e.Id == id);
            if (compra == null) return NotFound("No existe la compra buscada.");

            compra.UsuarioId = entidad.UsuarioId;
            compra.Fecha = entidad.Fecha;
            compra.Descripcion = entidad.Descripcion;

            try
            {
                context.Compras.Update(compra);
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
            var existe = await context.Compras.AnyAsync(x => x.Id == id);
            if (!existe) return NotFound($"La compra {id} no existe.");

            var entidad = new Compra { Id = id };
            context.Remove(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
