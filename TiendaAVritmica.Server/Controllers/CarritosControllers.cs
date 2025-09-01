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
    [Route("api/Carritos")]
    public class CarritosControllers : ControllerBase
    {
        //private readonly Context context;
        private readonly ICarritoRepositorio repositorio;
        private readonly IMapper mapper;

        public CarritosControllers(ICarritoRepositorio repositorio,
                                     IMapper mapper)
        {
            //this.context = context;
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        // GET: api/Carritos
        [HttpGet]
        public async Task<ActionResult<List<Carrito>>> Get()
        {
            return await repositorio.Select();
            //return await context.Carritos
            //                     .AsNoTracking()
            //                     .ToListAsync();
        }

        // GET: api/Carritos/2
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Carrito>> Get(int id)
        {
            Carrito? Ca = await repositorio.SelectById(id);
            //Carrito? Ca = await context.Carritos
            //              .FirstOrDefaultAsync(x => x.Id == id);

            if (Ca == null)
            {
                return NotFound();
            }

            return Ca;
        }

        [HttpGet("existe/{id:int}")] //api/Carritos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }
        
        // POST: api/Carrito
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearCarritoDTO entidadDTO)
        {
            try
            {
                //Carrito entidad = new Carrito();
                //entidad.FechaCreacion = entidadDTO.FechaCreacion;
                //entidad.Estado = entidadDTO.Estado;
                //entidad.FechaConfirmacion = entidadDTO.FechaConfirmacion;
                //entidad.EstadoPago = entidadDTO.EstadoPago;
                //entidad.MontoTotal = entidadDTO.MontoTotal;
                //entidad.Saldo = entidadDTO.Saldo;
                //entidad.DireccionEnvio = entidadDTO.DireccionEnvio;

                Carrito entidad = mapper.Map<Carrito>(entidadDTO);
                return await repositorio.Insert(entidad);
                //context.Carritos.Add(entidad);
                //await context.SaveChangesAsync();
                //return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);

            }
        }

        // PUT: api/Carritos/2
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Carrito entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrrectos");
            }
            var Ca = await repositorio.SelectById(id);
            //var Ca = await context.Carritos
            //              .Where(e => e.Id == id)
            //              .FirstOrDefaultAsync();

            if (Ca == null)
            {
                return NotFound("No existe el carrito buscado.");
            }

            Ca.UsuarioId = entidad.UsuarioId;
            Ca.FechaCreacion = entidad.FechaCreacion;
            Ca.Estado = entidad.Estado;
            Ca.FechaConfirmacion = entidad.FechaConfirmacion;
            Ca.EstadoPago = entidad.EstadoPago;
            Ca.MontoTotal = entidad.MontoTotal;
            Ca.Saldo = entidad.Saldo;
            Ca.DireccionEnvio = entidad.DireccionEnvio;
            Ca.Activo = entidad.Activo;

            try
            {
                await repositorio.Update(id, Ca);
                //context.Carritos.Update(Ca);
                //await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Carritos/2
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            //var existe = await context.Carritos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El carrito {id} no existe.");
            }

            //Carrito EntidadABorrar = new Carrito();
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
