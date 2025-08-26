using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Controllers
{
    [ApiController]
    [Route("api/CompraDetalles")]
    public class CompraDetallesController : ControllerBase
    {
        private readonly Context context;

        public CompraDetallesController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompraDetalle>>> Get()
        {
            return await context.CompraDetalles
                                .Include(cd => cd.Compra)
                                .Include(cd => cd.Producto)
                                .AsNoTracking()
                                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CompraDetalle>> Get(int id)
        {
            var detalle = await context.CompraDetalles
                                       .Include(cd => cd.Compra)
                                       .Include(cd => cd.Producto)
                                       .FirstOrDefaultAsync(x => x.Id == id);
            if (detalle == null) return NotFound();
            return detalle;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CompraDetalle entidad)
        {
            try
            {
                context.CompraDetalles.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CompraDetalle entidad)
        {
            if (id != entidad.Id) return BadRequest("Datos incorrectos");

            var detalle = await context.CompraDetalles.FirstOrDefaultAsync(e => e.Id == id);
            if (detalle == null) return NotFound("No existe el detalle de compra buscado.");

            detalle.CompraId = entidad.CompraId;
            detalle.ProductoId = entidad.ProductoId;
            detalle.Cantidad = entidad.Cantidad;
            detalle.PrecioCompra= entidad.PrecioCompra;

            try
            {
                context.CompraDetalles.Update(detalle);
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
            var existe = await context.CompraDetalles.AnyAsync(x => x.Id == id);
            if (!existe) return NotFound($"El detalle de compra {id} no existe.");

            var entidad = new CompraDetalle { Id = id };
            context.Remove(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
