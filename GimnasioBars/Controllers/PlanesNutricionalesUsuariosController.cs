using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GimnasioBars.Models;
using GimnasioBars.Attributes;

namespace GimnasioBars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class PlanesNutricionalesUsuariosController : ControllerBase
    {
        private readonly Gimnasio_BarsContext _context;

        public PlanesNutricionalesUsuariosController(Gimnasio_BarsContext context)
        {
            _context = context;
        }

        // GET: api/PlanesNutricionalesUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanesNutricionalesUsuario>>> GetPlanesNutricionalesUsuarios()
        {
          if (_context.PlanesNutricionalesUsuarios == null)
          {
              return NotFound();
          }
            return await _context.PlanesNutricionalesUsuarios.ToListAsync();
        }

        // GET: api/PlanesNutricionalesUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanesNutricionalesUsuario>> GetPlanesNutricionalesUsuario(int id)
        {
          if (_context.PlanesNutricionalesUsuarios == null)
          {
              return NotFound();
          }
            var planesNutricionalesUsuario = await _context.PlanesNutricionalesUsuarios.FindAsync(id);

            if (planesNutricionalesUsuario == null)
            {
                return NotFound();
            }

            return planesNutricionalesUsuario;
        }

        // PUT: api/PlanesNutricionalesUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanesNutricionalesUsuario(int id, PlanesNutricionalesUsuario planesNutricionalesUsuario)
        {
            if (id != planesNutricionalesUsuario.IdPlanNutricionalUsuario)
            {
                return BadRequest();
            }

            _context.Entry(planesNutricionalesUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanesNutricionalesUsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlanesNutricionalesUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlanesNutricionalesUsuario>> PostPlanesNutricionalesUsuario(PlanesNutricionalesUsuario planesNutricionalesUsuario)
        {
          if (_context.PlanesNutricionalesUsuarios == null)
          {
              return Problem("Entity set 'Gimnasio_BarsContext.PlanesNutricionalesUsuarios'  is null.");
          }
            _context.PlanesNutricionalesUsuarios.Add(planesNutricionalesUsuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlanesNutricionalesUsuarioExists(planesNutricionalesUsuario.IdPlanNutricionalUsuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlanesNutricionalesUsuario", new { id = planesNutricionalesUsuario.IdPlanNutricionalUsuario }, planesNutricionalesUsuario);
        }

        // DELETE: api/PlanesNutricionalesUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanesNutricionalesUsuario(int id)
        {
            if (_context.PlanesNutricionalesUsuarios == null)
            {
                return NotFound();
            }
            var planesNutricionalesUsuario = await _context.PlanesNutricionalesUsuarios.FindAsync(id);
            if (planesNutricionalesUsuario == null)
            {
                return NotFound();
            }

            _context.PlanesNutricionalesUsuarios.Remove(planesNutricionalesUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanesNutricionalesUsuarioExists(int id)
        {
            return (_context.PlanesNutricionalesUsuarios?.Any(e => e.IdPlanNutricionalUsuario == id)).GetValueOrDefault();
        }
    }
}
