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
    public class RutinasController : ControllerBase
    {
        private readonly Gimnasio_BarsContext _context;

        public RutinasController(Gimnasio_BarsContext context)
        {
            _context = context;
        }

        // GET: api/Rutinas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rutina>>> GetRutinas()
        {
          if (_context.Rutinas == null)
          {
              return NotFound();
          }
            return await _context.Rutinas.ToListAsync();
        }

        // GET: api/Rutinas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rutina>> GetRutina(int id)
        {
          if (_context.Rutinas == null)
          {
              return NotFound();
          }
            var rutina = await _context.Rutinas.FindAsync(id);

            if (rutina == null)
            {
                return NotFound();
            }

            return rutina;
        }

        // PUT: api/Rutinas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRutina(int id, Rutina rutina)
        {
            if (id != rutina.IdRutina)
            {
                return BadRequest();
            }

            _context.Entry(rutina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutinaExists(id))
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

        // POST: api/Rutinas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rutina>> PostRutina(Rutina rutina)
        {
          if (_context.Rutinas == null)
          {
              return Problem("Entity set 'Gimnasio_BarsContext.Rutinas'  is null.");
          }
            _context.Rutinas.Add(rutina);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RutinaExists(rutina.IdRutina))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRutina", new { id = rutina.IdRutina }, rutina);
        }

        // DELETE: api/Rutinas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRutina(int id)
        {
            if (_context.Rutinas == null)
            {
                return NotFound();
            }
            var rutina = await _context.Rutinas.FindAsync(id);
            if (rutina == null)
            {
                return NotFound();
            }

            _context.Rutinas.Remove(rutina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RutinaExists(int id)
        {
            return (_context.Rutinas?.Any(e => e.IdRutina == id)).GetValueOrDefault();
        }
    }
}
