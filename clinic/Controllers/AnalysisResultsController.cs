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
            return Ok(await _context.Analysisresults.Where(t => t.Client == id).ToListAsync());
        }

        /*[Authorize]
        [HttpPost]
        public async Task<ActionResult> AddAnalysisResults(int[] analyzesId)
        {
            List<Analysisresult> results = new List<Analysisresult>();
            var clientId = int.Parse(User.Claims.Where(c => c.Type == "ClientId").Select(c => c.Value).FirstOrDefault());
            for (int i = 0; i < analyzesId.Length; i++)
            {
                results.Add(new Analysisresult
                {
                    Status = "Ожидается посещение",
                    Client = clientId,
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    Analysistype = analyzesId[i],
                    AnalysistypeNavigation = _context.Analysistypes.Find(analyzesId[i])
                });
            };
            await _context.Analysisresults.AddRangeAsync(results);
            _context.SaveChanges();
            return Ok();
        }*/
    }
}
