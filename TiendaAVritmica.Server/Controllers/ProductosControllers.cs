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
    [Route("api/Productos")]
    public class ProductosController : ControllerBase
    {
        //private readonly Context context;
        private readonly IProductoRepositorio repositorio;
        private readonly IMapper mapper;

        public ProductosController(IProductoRepositorio repositorio,
                                   IMapper mapper)
        {
            //this.context = context;
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await repositorio.Select();
            //return await context.Productos
            //                    .Include(p => p.Categoria) // 👈 Incluye la categoría
            //                    .AsNoTracking()
            //                    .ToListAsync();
        }

        // GET: api/Productos/2
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            Producto? p = await repositorio.SelectById(id);
            //var p = await context.Productos
            //              .Include(p => p.Categoria)
            //              .FirstOrDefaultAsync(x => x.Id == id);

            if (p == null)
            {
                return NotFound();
            }

            return p;
        }

        [HttpGet("existe/{id:int}")] //api/Producto/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearProductoDTO entidadDTO)
        {
            try
            {
                Producto entidad = mapper.Map<Producto>(entidadDTO);

                return await repositorio.Insert(entidad);
                //Producto entidad = new Producto();
                //entidad.Nombre= entidadDTO.Nombre;
                //entidad.Descripcion= entidadDTO.Descripcion;
                //entidad.Precio = entidadDTO.Precio;
                //entidad.Stock = entidadDTO.Stock;
                //entidad.ImagenUrl = entidadDTO.ImagenUrl;
                //entidad.CategoriaId = entidadDTO.CategoriaId;

                //Producto entidad = mapper.Map<Producto>(entidadDTO);
                //context.Productos.Add(entidad);
                //await context.SaveChangesAsync();
                //return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // PUT: api/Productos/2
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Producto entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var p = await repositorio.SelectById(id);
            //var p = await context.Productos
            //             .Where(e => e.Id == id)
            //             .FirstOrDefaultAsync();
            if (p == null)
            {
                return NotFound("No existe el producto buscado.");
            }

            p.Nombre = entidad.Nombre;
            p.Descripcion = entidad.Descripcion;
            p.Precio = entidad.Precio;
            p.CategoriaId = entidad.CategoriaId;
            p.Activo = entidad.Activo;
            try
            {
                await repositorio.Update(id, p);
                return Ok();

                //context.Productos.Update(p);
                //await context.SaveChangesAsync();
                //return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Productos/2
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            //var existe = await context.Productos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El producto {id} no existe.");
            }
            //Producto EntidadABorrar = new Producto();
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
