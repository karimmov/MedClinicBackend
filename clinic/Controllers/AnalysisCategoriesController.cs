using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using clinic.Model;
using clinic.Model.Tables;

namespace clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisCategoriesController : ControllerBase
    {
        private readonly MedicalClinicContext _context;

        public AnalysisCategoriesController(MedicalClinicContext context)
        {
            _context = context;
        }

        // GET: api/AnalysisCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analysiscategory>>> GetAnalysiscategories()
        {
          if (_context.Analysiscategories == null)
          {
              return NotFound();
          }
            return await _context.Analysiscategories.ToListAsync();
        } 

        // GET: api/AnalysisCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Analysiscategory>> GetAnalysiscategory(int id)
        {
          if (_context.Analysiscategories == null)
          {
              return NotFound();
          }
            var analysiscategory = await _context.Analysiscategories.FindAsync(id);

            if (analysiscategory == null)
            {
                return NotFound();
            }

            return analysiscategory;
        }

        // PUT: api/AnalysisCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalysiscategory(int id, Analysiscategory analysiscategory)
        {
            if (id != analysiscategory.Categoryid)
            {
                return BadRequest();
            }

            _context.Entry(analysiscategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalysiscategoryExists(id))
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

        // POST: api/AnalysisCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Analysiscategory>> PostAnalysiscategory(Analysiscategory analysiscategory)
        {
          if (_context.Analysiscategories == null)
          {
              return Problem("Entity set 'MedicalClinicContext.Analysiscategories'  is null.");
          }
            _context.Analysiscategories.Add(analysiscategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalysiscategory", new { id = analysiscategory.Categoryid }, analysiscategory);
        }

        // DELETE: api/AnalysisCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalysiscategory(int id)
        {
            if (_context.Analysiscategories == null)
            {
                return NotFound();
            }
            var analysiscategory = await _context.Analysiscategories.FindAsync(id);
            if (analysiscategory == null)
            {
                return NotFound();
            }

            _context.Analysiscategories.Remove(analysiscategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnalysiscategoryExists(int id)
        {
            return (_context.Analysiscategories?.Any(e => e.Categoryid == id)).GetValueOrDefault();
        }
    }
}
