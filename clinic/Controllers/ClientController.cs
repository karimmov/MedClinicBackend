using clinic.Model.Tables;
using clinic.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol;
using Microsoft.EntityFrameworkCore;

namespace clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly MedicalClinicContext _context;
        public ClientController(MedicalClinicContext context) { _context = context; }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Client>> GetClient()
        {
            var id = User.Identity.Name;

            if (_context.Clients == null) return NotFound();

            var client = await _context.Clients.FindAsync(int.Parse(id));

            if (client == null) return NotFound();

            Console.WriteLine(client.Name);

            return Ok(client.ToJson());
        }

        //[HttpGet]
        //public async Task<ActionResult<Client>> GetClientTest(int id)
        //{

        //    if (_context.Clients == null) return NotFound();

        //    var client = await _context.Clients.FindAsync(id);

        //    if (client == null) return NotFound();

        //    return client;
        //}

        [HttpPost]
        public async Task<ActionResult> PostClient(string name, string email, string password)
        {
            if (_context.Clients.ToList().Find(x => x.Email == email) != null)
                return Problem("Пользователь с таким email уже зарегистрирован");
            var id = _context.Clients.ToList().Last().Clientid + 1;
            await _context.Clients.AddAsync(new Client()
            {
                Clientid = id,
                Name = name,
                Email = email,
                Passwordhash = password
            });
            await _context.SaveChangesAsync();
            return Ok();
        } 
    }
}
