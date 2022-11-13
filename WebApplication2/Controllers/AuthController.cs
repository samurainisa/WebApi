using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Server.Data;
using Server.DTOs;
using Server.Models;


namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DataContext _context;

        public AuthController(IConfiguration config, DataContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("/login")]
        public async Task<ActionResult<AuthResponseDto>> Token(ParameterLoginDto data)
        {
            var identity = GetIdentity(data.Email, data.Password);

            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            //add secret to token response
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new AuthResponseDto
            {
                access_token = encodedJwt,
                email = identity.Name,
                role = identity.Claims.Where(c => c.Type == "Role")
                    .Select(c => c.Value).FirstOrDefault(),
                userID = identity.Claims.Where(c => c.Type == "Id")
                    .Select(c => c.Value).FirstOrDefault()
            };

            return Ok(response);
        }


        [HttpPost("/signin")]
        public async Task<ActionResult<CreateUserLoginDto>> Register(ClientModel request)
        {
            var user = new User
            {
                Email = request.Email,
            };
            var userLogin = new UserLogin
            {
                Email = user.Email,
                Password = request.Password,
                Role = request.Role,
                User = user
            };

            var userlogindto = new CreateUserLoginDto
            {
                Id = userLogin.UserId,
                Email = userLogin.Email,
                Password = userLogin.Password,
                Role = userLogin.Role,
            };

            _context.Users.Add(user);
            _context.UserLogins.Add(userLogin);

            await _context.SaveChangesAsync();

            return Ok(userlogindto);
        }





        private ClaimsIdentity GetIdentity(string email, string password)
        {
            // UserLogin person = _context.UserLogins.FirstOrDefault(x => x.Email == email && x.Password == password);
            UserLogin person = _context.UserLogins.FirstOrDefault(x => x.Email == email);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new(ClaimsIdentity.DefaultNameClaimType, person.Email),
                    new(ClaimsIdentity.DefaultRoleClaimType, person.Role),
                    new("Role", person.Role),
                    new("Id", person.UserId.ToString())
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}