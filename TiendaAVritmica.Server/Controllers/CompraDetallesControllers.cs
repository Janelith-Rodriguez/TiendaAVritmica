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
    [Route("api/CompraDetalles")]
    public class CompraDetallesController : ControllerBase
    {
        //private readonly Context context;
        private readonly ICompraDetalleRepositorio repositorio;
        private readonly IMapper mapper;

        public CompraDetallesController(ICompraDetalleRepositorio repositorio,
                                        IMapper mapper)
        {
            //this.context = context;
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompraDetalle>>> Get()
        {
            return await repositorio.Select();
            //return await context.CompraDetalles
            //                    .Include(cd => cd.Compra)
            //                    .Include(cd => cd.Producto)
            //                    .AsNoTracking()
            //                    .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CompraDetalle>> Get(int id)
        {
            CompraDetalle? cd = await repositorio.SelectById(id);
            //CompraDetalle? cd = await context.CompraDetalles
            //                           .Include(cd => cd.Compra)
            //                           .Include(cd => cd.Producto)
            //                           .FirstOrDefaultAsync(x => x.Id == id);
            if (cd == null)
            {
                return NotFound();
            }
            return cd;
        }

        [HttpGet("existe/{id:int}")] //api/CompraDetalles/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearCompraDetalleDTO entidadDTO)
        {
            try
            {
                //CompraDetalle entidad = new CompraDetalle();
                //entidad.Cantidad = entidadDTO.Cantidad;
                //entidad.PrecioCompra = entidadDTO.PrecioCompra;
                //entidad.PrecioVentaActualizado = entidadDTO.PrecioVentaActualizado;

                CompraDetalle entidad = mapper.Map<CompraDetalle>(entidadDTO);
                return await repositorio.Insert(entidad);
                //context.CompraDetalles.Add(entidad);
                //await context.SaveChangesAsync();
                //return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CompraDetalle entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var cd = await repositorio.SelectById(id);
            //var cd = await context.CompraDetalles
            //    .FirstOrDefaultAsync(e => e.Id == id);
            
            if (cd == null)
            {
                return NotFound("No existe el detalle de compra buscado.");
            }
            cd.CompraId = entidad.CompraId;
            cd.ProductoId = entidad.ProductoId;
            cd.Cantidad = entidad.Cantidad;
            cd.PrecioCompra= entidad.PrecioCompra;

            try
            {
                await repositorio.Update(id, cd);
                return Ok();
                //context.CompraDetalles.Update(detalle);
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
            //var existe = await context.CompraDetalles
            //                  .AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El detalle de compra {id} no existe.");
            }
            //CompraDetalle EntidadABorrar = new CompraDetalle();
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
