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
    [Route("api/StockMovimientos")]
    public class StockMovimientosControllers : ControllerBase
    {
        private readonly IStockMovimientoRepositorio repositorio;
        //private readonly Context context;
        private readonly IMapper mapper;

        public StockMovimientosControllers(IStockMovimientoRepositorio repositorio,
                                     IMapper mapper)
        {
            this.repositorio = repositorio;
            //this.context = context;
            this.mapper = mapper;
        }

        // GET: api/StockMovimientos
        [HttpGet]
        public async Task<ActionResult<List<StockMovimiento>>> Get()
        {
            return await repositorio.Select();
            //return await context.StockMovimientos
            //                     .AsNoTracking()
            //                     .ToListAsync();
        }

        // GET: api/StockMovimientos/2
        [HttpGet("{id:int}")]
        public async Task<ActionResult<StockMovimiento>> Get(int id)
        {
            StockMovimiento? SM = await repositorio.SelectById(id);
            if (SM == null)
            {
                return NotFound();
            }
            return SM;
            //StockMovimiento? SM = await context.StockMovimientos
            //              .FirstOrDefaultAsync(x => x.Id == id);

            //if (SM == null)
            //{
            //    return NotFound();
            //}

            //return SM;
        }

        [HttpGet("existe/{id:int}")] //api/StockMovimiento/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        // POST: api/StockMovimientos
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearStockMovimientoDTO entidadDTO)
        {
            try
            {
                StockMovimiento entidad = mapper.Map<StockMovimiento>(entidadDTO);

                return await repositorio.Insert(entidad);
                //StockMovimiento entidad = new StockMovimiento();
                //entidad.Cantidad = entidadDTO.Cantidad;
                //entidad.Fecha = entidadDTO.Fecha;
                //entidad.Descripcion = entidadDTO.Descripcion;

                //StockMovimiento entidad = mapper.Map<StockMovimiento>(entidadDTO);
                //context.StockMovimientos.Add(entidad);
                //await context.SaveChangesAsync();
                //return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);

            }
        }
        
        // PUT: api/StockMovimientos/2
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StockMovimiento entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrrectos");
            }
            var SM = await repositorio.SelectById(id);
            //var SM = await context.StockMovimientos
            //              .Where(e => e.Id == id)
            //              .FirstOrDefaultAsync();

            if (SM == null)
            {
                return NotFound("No existe el carrito buscado.");
            }

            SM.ProductoId = entidad.ProductoId;
            SM.TipoMovimiento = entidad.TipoMovimiento;
            SM.Cantidad = entidad.Cantidad;
            SM.Fecha = entidad.Fecha;
            SM.Descripcion = entidad.Descripcion;
            SM.Activo = entidad.Activo;

            try
            {
                await repositorio.Update(id, SM);
                return Ok();

                //context.StockMovimientos.Update(SM);
                //await context.SaveChangesAsync();
                //return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/StockMovimientos/2
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            //var existe = await context.StockMovimientos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El Stock Movimiento {id} no existe.");
            }

            //StockMovimiento EntidadABorrar = new StockMovimiento();
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
