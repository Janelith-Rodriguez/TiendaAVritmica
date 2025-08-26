using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaAVritmica.BD.Data;
using TiendaAVritmica.BD.Data.Entity;

namespace TiendaAVritmica.Server.Controllers
{
    [ApiController]
    [Route("api/Categorias")]   
    public class CategoriasControllers : ControllerBase
    {
        private readonly Context context;

        public CategoriasControllers(Context context)
        {
            this.context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            return await context.Categorias
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // GET: api/Categorias/2
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            Categoria? V = await context.Categorias
                          .FirstOrDefaultAsync(x => x.Id == id);

            if (V == null)
            {
                return NotFound();
            }

            return V;
        }

        // POST: api/Categorias
        [HttpPost]
        public async Task<ActionResult<int>> Post(Categoria entidad)
        {
            try
            {
                context.Categorias.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        // PUT: api/Categorias/2
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categoria entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrrectos");
            }
            var V = await context.Categorias
                          .Where(e => e.Id == id)
                          .FirstOrDefaultAsync();

            if (V == null)
            {
                return NotFound("No existe la categoria buscada.");
            }

            V.Nombre=entidad.Nombre;
            V.Descripcion = entidad.Descripcion;
            V.Activo = entidad.Activo;

            try
            {
                context.Categorias.Update(V);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Categorias/2
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Categorias.AnyAsync(x => x.Id==id);
            if (!existe)
            {
                return NotFound($"La categoria {id} no existe.");
            }

            Categoria EntidadABorrar= new Categoria();
            EntidadABorrar.Id = id;

            context.Remove( EntidadABorrar );
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
