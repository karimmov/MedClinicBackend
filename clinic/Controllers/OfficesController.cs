using clinic.Model;
using clinic.Model.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController: ControllerBase
    {
        private readonly MedicalClinicContext _context;

        public OfficesController(MedicalClinicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Office>>> GetOffices()
        {
            return await _context.Offices.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetOfficeName(int id)
        {
            var office = await _context.Offices.FindAsync(id);
            if (office == null) return NotFound();
            return office.Officeaddress;
        }
    }
}
