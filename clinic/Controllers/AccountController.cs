﻿using clinic.Model;
using clinic.Model.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using NuGet.Protocol;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using System.Text;

namespace clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MedicalClinicContext _context;

        public AccountController(MedicalClinicContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("/api/checkIsAuthenticated")]
        public IActionResult CheckIsAuthenticated()
        {
            return Ok();
        }

        [HttpPost("/api/authenticate")]
        public IActionResult Authenticate(string username, string password)
        {
            var passwordhash = CalculateMD5Hash(password);
            var identity = GetIdentity(username, passwordhash);
            if (identity.Result == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Result.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Result.Name
            };

            return Ok(response.ToJson());
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

        private async Task<ClaimsIdentity?> GetIdentity(string username, string password)
        {
            Client? person = await _context.Clients.FirstOrDefaultAsync(client => client.Email == username && client.Passwordhash == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("ClientId", person.Clientid.ToString()),
                };
                //ClaimsIdentity claimsIdentity =
                //new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                //    ClaimsIdentity.DefaultRoleClaimType);
                var claimsIdentity = new ClaimsIdentity(claims);
                return claimsIdentity;
            }
            return null;
        }
    }
}
