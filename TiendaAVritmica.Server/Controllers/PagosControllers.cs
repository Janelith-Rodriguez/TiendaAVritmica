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
    [Route("api/Pagos")]
    public class PagosControllers : ControllerBase
    {
        //private readonly Context context;
        private readonly IPagoRepositorio repositorio;
        private readonly IMapper mapper;

        public PagosControllers(IPagoRepositorio repositorio,
                                     IMapper mapper)
        {
            //this.context = context;
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        // GET: api/Pagos
        [HttpGet]
        public async Task<ActionResult<List<Pago>>> Get()
        {
            return await repositorio.Select();
            //return await context.Pagos
            //                     .AsNoTracking()
            //                     .ToListAsync();
        }

        // GET: api/Pagos/2
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pago>> Get(int id)
        {
            Pago? P = await repositorio.SelectById(id);
            //Pago? V = await context.Pagos
            //              .FirstOrDefaultAsync(x => x.Id == id);

            if (P == null)
            {
                return NotFound();
            }

            return P;
        }

        [HttpGet("existe/{id:int}")] //api/Pagos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }
        // POST: api/Pagos
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPagoDTO entidadDTO)
        {
            try
            {
                //Pago entidad = new Pago();
                //entidad.FechaPago = entidadDTO.FechaPago;
                //entidad.MetodoPago = entidadDTO.MetodoPago;
                //entidad.MontoPagado = entidadDTO.MontoPagado;
                //entidad.EstadoPago = entidadDTO.EstadoPago;
                //entidad.Saldo = entidadDTO.Saldo;

                Pago entidad = mapper.Map<Pago>(entidadDTO);
                return await repositorio.Insert(entidad);
                //context.Pagos.Add(entidad);
                //await context.SaveChangesAsync();
                //return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);

            }
        }

        // PUT: api/Pagos/2
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Pago entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrrectos");
            }
            var P = await repositorio.SelectById(id);
            //var P = await context.Pagos
            //              .Where(e => e.Id == id)
            //              .FirstOrDefaultAsync();

            if (P == null)
            {
                return NotFound("No existe el pago buscado.");
            }

            P.CarritoId = entidad.CarritoId;
            P.FechaPago = entidad.FechaPago;
            P.MetodoPago = entidad.MetodoPago;
            P.MontoPagado = entidad.MontoPagado;
            P.EstadoPago = entidad.EstadoPago;
            P.Saldo = entidad.Saldo;
            P.Activo = entidad.Activo;

            try
            {
                await repositorio.Update(id, P);
                return Ok();

                //context.Pagos.Update(P);
                //await context.SaveChangesAsync();
                //return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // DELETE: api/Pagos/2
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            //var existe = await context.Pagos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El pago {id} no existe.");
            }

            //Pago EntidadABorrar = new Pago();
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

