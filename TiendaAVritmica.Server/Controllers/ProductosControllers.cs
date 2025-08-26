using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductosController : ControllerBase
    {
        private readonly Context context;

        public ProductosController(Context context)
        {
            this.context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await context.Productos
                                 .Include(p => p.Categoria) // 👈 Incluye la categoría
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // GET: api/Productos/2
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await context.Productos
                          .Include(p => p.Categoria)
                          .FirstOrDefaultAsync(x => x.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<int>> Post(Producto entidad)
        {
            try
            {
                context.Productos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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

            var producto = await context.Productos.FirstOrDefaultAsync(e => e.Id == id);
            if (producto == null)
            {
                return NotFound("No existe el producto buscado.");
            }

            producto.Nombre = entidad.Nombre;
            producto.Descripcion = entidad.Descripcion;
            producto.Precio = entidad.Precio;
            producto.Activo = entidad.Activo;
            producto.CategoriaId = entidad.CategoriaId;

            try
            {
                context.Productos.Update(producto);
                await context.SaveChangesAsync();
                return Ok();
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
            var existe = await context.Productos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El producto {id} no existe.");
            }

            var entidad = new Producto { Id = id };
            context.Remove(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
