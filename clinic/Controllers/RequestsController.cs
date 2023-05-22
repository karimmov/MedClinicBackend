using clinic.Model.Tables;
using clinic.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol;
using Microsoft.EntityFrameworkCore;


namespace clinic.Controllers
{
    public class CustomRequest
    {
        public int Analysistype { get; set; }
        public int Office { get; set; }
        public DateOnly? Date { get; set; }
    }
        
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController: ControllerBase
    {
        private readonly MedicalClinicContext _context;

        public RequestsController(MedicalClinicContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequestsByUser() 
        {
            var id = User.Claims.Where(t => t.Type == "ClientId").Select(t => t.Value).Single();

            return await _context.Requests.Where(t => t.Client == int.Parse(id)).ToListAsync();

        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostAnalysiscategory(CustomRequest data)
        {
            var id = User.Claims.Where(t => t.Type == "ClientId").Select(t => t.Value).Single();

            var request = new Request()
            {
                Client = int.Parse(id),
                Office = data.Office,
                Receptiondate = data.Date,
                Analysistype = data.Analysistype,
            };

            if (_context.Requests == null)
            {
                return Problem("Entity set 'MedicalClinicContext.Requests'  is null.");
            }
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
