using clinic.Model;
using clinic.Model.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisResultsController : ControllerBase
    {
        private readonly MedicalClinicContext _context;
        public AnalysisResultsController(MedicalClinicContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analysisresult>>> GetAnalysisResults()
        {
            var user = User;
            Console.WriteLine(user);
            return Ok();
        }
    }
}
