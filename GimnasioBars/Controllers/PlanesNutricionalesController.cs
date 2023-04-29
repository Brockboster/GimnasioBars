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
    public class PlanesNutricionalesController : ControllerBase
    {
        private readonly Gimnasio_BarsContext _context;

        public PlanesNutricionalesController(Gimnasio_BarsContext context)
        {
            _context = context;
        }

        // GET: api/PlanesNutricionales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanesNutricionale>>> GetPlanesNutricionales()
        {
          if (_context.PlanesNutricionales == null)
          {
              return NotFound();
          }
            return await _context.PlanesNutricionales.ToListAsync();
        }

        // GET: api/PlanesNutricionales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanesNutricionale>> GetPlanesNutricionale(int id)
        {
          if (_context.PlanesNutricionales == null)
          {
              return NotFound();
          }
            var planesNutricionale = await _context.PlanesNutricionales.FindAsync(id);

            if (planesNutricionale == null)
            {
                return NotFound();
            }

            return planesNutricionale;
        }

        // PUT: api/PlanesNutricionales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanesNutricionale(int id, PlanesNutricionale planesNutricionale)
        {
            if (id != planesNutricionale.IdPlanNutricional)
            {
                return BadRequest();
            }

            _context.Entry(planesNutricionale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanesNutricionaleExists(id))
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

        // POST: api/PlanesNutricionales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlanesNutricionale>> PostPlanesNutricionale(PlanesNutricionale planesNutricionale)
        {
          if (_context.PlanesNutricionales == null)
          {
              return Problem("Entity set 'Gimnasio_BarsContext.PlanesNutricionales'  is null.");
          }
            _context.PlanesNutricionales.Add(planesNutricionale);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlanesNutricionaleExists(planesNutricionale.IdPlanNutricional))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlanesNutricionale", new { id = planesNutricionale.IdPlanNutricional }, planesNutricionale);
        }

        // DELETE: api/PlanesNutricionales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanesNutricionale(int id)
        {
            if (_context.PlanesNutricionales == null)
            {
                return NotFound();
            }
            var planesNutricionale = await _context.PlanesNutricionales.FindAsync(id);
            if (planesNutricionale == null)
            {
                return NotFound();
            }

            _context.PlanesNutricionales.Remove(planesNutricionale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanesNutricionaleExists(int id)
        {
            return (_context.PlanesNutricionales?.Any(e => e.IdPlanNutricional == id)).GetValueOrDefault();
        }
    }
}
