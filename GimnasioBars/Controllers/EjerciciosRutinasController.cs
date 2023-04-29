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
    public class EjerciciosRutinasController : ControllerBase
    {
        private readonly Gimnasio_BarsContext _context;

        public EjerciciosRutinasController(Gimnasio_BarsContext context)
        {
            _context = context;
        }

        // GET: api/EjerciciosRutinas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EjerciciosRutina>>> GetEjerciciosRutinas()
        {
          if (_context.EjerciciosRutinas == null)
          {
              return NotFound();
          }
            return await _context.EjerciciosRutinas.ToListAsync();
        }

        // GET: api/EjerciciosRutinas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EjerciciosRutina>> GetEjerciciosRutina(int id)
        {
          if (_context.EjerciciosRutinas == null)
          {
              return NotFound();
          }
            var ejerciciosRutina = await _context.EjerciciosRutinas.FindAsync(id);

            if (ejerciciosRutina == null)
            {
                return NotFound();
            }

            return ejerciciosRutina;
        }

        // PUT: api/EjerciciosRutinas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEjerciciosRutina(int id, EjerciciosRutina ejerciciosRutina)
        {
            if (id != ejerciciosRutina.IdEjercicioRutina)
            {
                return BadRequest();
            }

            _context.Entry(ejerciciosRutina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EjerciciosRutinaExists(id))
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

        // POST: api/EjerciciosRutinas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EjerciciosRutina>> PostEjerciciosRutina(EjerciciosRutina ejerciciosRutina)
        {
          if (_context.EjerciciosRutinas == null)
          {
              return Problem("Entity set 'Gimnasio_BarsContext.EjerciciosRutinas'  is null.");
          }
            _context.EjerciciosRutinas.Add(ejerciciosRutina);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EjerciciosRutinaExists(ejerciciosRutina.IdEjercicioRutina))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEjerciciosRutina", new { id = ejerciciosRutina.IdEjercicioRutina }, ejerciciosRutina);
        }

        // DELETE: api/EjerciciosRutinas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEjerciciosRutina(int id)
        {
            if (_context.EjerciciosRutinas == null)
            {
                return NotFound();
            }
            var ejerciciosRutina = await _context.EjerciciosRutinas.FindAsync(id);
            if (ejerciciosRutina == null)
            {
                return NotFound();
            }

            _context.EjerciciosRutinas.Remove(ejerciciosRutina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EjerciciosRutinaExists(int id)
        {
            return (_context.EjerciciosRutinas?.Any(e => e.IdEjercicioRutina == id)).GetValueOrDefault();
        }
    }
}
