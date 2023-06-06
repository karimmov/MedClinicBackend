using clinic.Model.Tables;
using clinic.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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
            var id = User.Claims.Where(t => t.Type == "ClientId").Select(t => t.Value).Single();

            if (_context.Clients == null) return NotFound();

            var client = await _context.Clients.FindAsync(int.Parse(id));

            if (client == null) return NotFound();

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
            await _context.Clients.AddAsync(new Client()
            {
                Clientname = name,
                Email = email,
                Passwordhash = CalculateMD5Hash(password),    
            });
            await _context.SaveChangesAsync();
            return Ok();
        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        private bool ClientExist(int id)
        {
            return (_context.Clients?.Any(e => e.Clientid == id)).GetValueOrDefault();
        }
    }
}
