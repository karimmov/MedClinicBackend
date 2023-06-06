using clinic.Model;
using clinic.Model.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisResultsController : ControllerBase
    {
        private readonly MedicalClinicContext _context;

        public AnalysisResultsController(MedicalClinicContext context) { _context = context; }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analysisresult>>> GetAnalysisResults()
        {
            var id = int.Parse(User.Claims.Where(c => c.Type == "ClientId").Select(c => c.Value).FirstOrDefault());

            var result = await _context.Analysisresults.Where(t => t.Client == id).ToListAsync();

            foreach (var analysisresult in result)
            {
                analysisresult.AnalysistypeNavigation = _context.Analysistypes.Find(analysisresult.Analysistype);
                analysisresult.OfficeNavigation = _context.Offices.Find(analysisresult.Office);
            }

            return Ok(result);
        }

        /*[HttpPost]
        public async Task<ActionResult> AddAnalysisResults(Analysisresult analysisresult)
        {
            await _context.Analysisresults.AddRangeAsync(analysisresult);
            _context.SaveChanges();
            return Ok();
        }*/
    }
}
