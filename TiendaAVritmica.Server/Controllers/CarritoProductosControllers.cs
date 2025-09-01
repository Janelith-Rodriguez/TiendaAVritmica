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
    [Route("api/CarritoProductos")]
    public class CarritoProductosControllers : ControllerBase
    {
        //private readonly Context context;
        private readonly ICarritoProductoRepositorio repositorio;
        private readonly IMapper mapper;

        public CarritoProductosControllers(ICarritoProductoRepositorio repositorio,
                                     IMapper mapper)
        {
            //this.context = context;
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        // GET: api/CarritoProductos
        [HttpGet]
        public async Task<ActionResult<List<CarritoProducto>>> Get()
        {
            return await repositorio.Select();
            //return await context.CarritoProductos
            //                     .AsNoTracking()
            //                     .ToListAsync();
        }

        // GET: api/CarritoProductos/2
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarritoProducto>> Get(int id)
        {
            CarritoProducto? CaP = await repositorio.SelectById(id);
            //CarritoProducto? CaP = await context.CarritoProductos
            //              .FirstOrDefaultAsync(x => x.Id == id);

            if (CaP == null)
            {
                return NotFound();
            }

            return CaP;
        }

        [HttpGet("existe/{id:int}")] //api/CarritoProductos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
            //var existe = await repositorio.Existe(id);
            //return existe;
        }

        // POST: api/CarritoProductos
        [HttpPost]
        public async Task<ActionResult<int>> Post(CarritoProducto entidad)
        {
            try
            {
                //CarritoProducto entidad = new CarritoProducto();
                //entidad.Cantidad = entidadDTO.Cantidad;
                //entidad.PrecioUnitario = entidadDTO.PrecioUnitario;

                //CarritoProducto entidad = mapper.Map<CarritoProducto>(entidadDTO);
                return await repositorio.Insert(entidad);
                //context.CarritoProductos.Add(entidad);
                //await context.SaveChangesAsync();
                //return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);

            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CarritoProducto entidad)
        {
            try 
            { 
                if (id != entidad.Id)
                {
                    return BadRequest("Datos incorrrectos");
                }
                var CaP = await repositorio.Update(id, entidad);
                //var CaP = await context.CarritoProductos
                //              .Where(e => e.Id == id)
                //              .FirstOrDefaultAsync();

                if (!CaP)
                {
                    return BadRequest("No se pudo actualizar el carrito producto.");
                }
                return Ok();

                //CaP.CarritoId = entidad.CarritoId;
                //CaP.ProductoId = entidad.ProductoId;
                //CaP.Cantidad = entidad.Cantidad;
                //CaP.PrecioUnitario = entidad.PrecioUnitario;
                //CaP.Activo = entidad.Activo;

                
                //await repositorio.Update(id, CaP);
                //return Ok();

                //context.CarritoProductos.Update(CP);
                //await context.SaveChangesAsync();
                //return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/CarritoProductos/2
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            //var existe = await context.CarritoProductos.AnyAsync(x => x.Id == id);
            if (!resp)
            {
                return BadRequest("El carrito producto no se pudo borrar.");
            }
            return Ok();

            //CarritoProducto EntidadABorrar = new CarritoProducto();
            //EntidadABorrar.Id = id;

            //context.Remove(EntidadABorrar);
            //await context.SaveChangesAsync();
            //return Ok();
            //if (await repositorio.Delete(id))
            //{
            //    return Ok();
            //}
            //else
            //{
            //    return BadRequest();
            //}
        }
    }
}
