using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using clinic.Model;
using clinic.Model.Tables;
using clinic.Model.DataTransfer;

namespace clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisTypesController : ControllerBase
    {
        private readonly MedicalClinicContext _context;

        public AnalysisTypesController(MedicalClinicContext context)
        {
            _context = context;
        }

       // GET: api/AnalysisTypes
       [HttpGet("{categoryId}")]
        public async Task<ActionResult<IEnumerable<Analysistype>>> GetAnalysisTypesByCategory(int categoryId)
        {
            if (_context.Analysistypes == null)
            {
                return NotFound();
            }
            return await _context.Analysistypes.Where(t => t.Category == categoryId).ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analysistype>>> GetAnalysisTypes()
        {
            if (_context == null)
            {
                return NotFound();
            }

            return await _context.Analysistypes.ToListAsync();
        }


        // GET: api/AnalysisTypes/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<Analysistype>> GetAnalysistype(int id)
        {
            if (_context.Analysistypes == null)
            {
                return NotFound();
            }
            var analysistype = await _context.Analysistypes.FindAsync(id);

            if (analysistype == null)
            {
                return NotFound();
            }

            return analysistype;
        }*/

        // PUT: api/AnalysisTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalysistype(int id, Analysistype analysistype)
        {
            if (id != analysistype.Analysisid)
            {
                return BadRequest();
            }

            _context.Entry(analysistype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalysistypeExists(id))
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

        // POST: api/AnalysisTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Analysistype>> PostAnalysistype(Analysistype analysistype)
        {
          if (_context.Analysistypes == null)
          {
              return Problem("Entity set 'MedicalClinicContext.Analysistypes'  is null.");
          }
            _context.Analysistypes.Add(analysistype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalysistype", new { id = analysistype.Analysisid }, analysistype);
        }

        // DELETE: api/AnalysisTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalysistype(int id)
        {
            if (_context.Analysistypes == null)
            {
                return NotFound();
            }
            var analysistype = await _context.Analysistypes.FindAsync(id);
            if (analysistype == null)
            {
                return NotFound();
            }

            _context.Analysistypes.Remove(analysistype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnalysistypeExists(int id)
        {
            return (_context.Analysistypes?.Any(e => e.Analysisid == id)).GetValueOrDefault();
        }
    }
}
