using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication.Data;
using WebApplication.DTOs;
using WebApplication.Models;

namespace WebApplication.Controllers
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
                expires: now.Add(TimeSpan.FromHours(3)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new AuthResponseDto
            {
                access_token = encodedJwt,
                Email = identity.Name,
                Role = identity.Claims.Where(c => c.Type == "Role")
                    .Select(c => c.Value).FirstOrDefault()
                //userID = identity.Claims.Where(c => c.Type == "Id")
                    //.Select(c => c.Value).FirstOrDefault()
            };

            return Ok(response);
        }

        private void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                passwordHash = Convert.ToBase64String(
                    hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))
                );
            }
        }

        [HttpPost("/signin")]
        public async Task<ActionResult<CreateUserLoginDto>> Register(ClientModel request)
        {
            CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

            //проверка на такого ще существующего пользователя
            var checkUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (checkUser != null)
            {
                return StatusCode(409, new { errorText = "Такой логин уже занят другим пользователем." });
            }


            var user = new User
            {
                Email = request.Email,
            };
            var userLogin = new UserLogin
            {
                Email = user.Email,
                Password = passwordHash,
                Role = "User",
                Salt = passwordSalt,
                User = user
            };

            var userlogindto = new CreateUserLoginDto
            {
                //Id = userLogin.UserId,
                Email = userLogin.Email,
                Password = userLogin.Password,
                Role = userLogin.Role,
            };

            _context.Users.Add(user);
            _context.UserLogins.Add(userLogin);

            await _context.SaveChangesAsync();

            return Ok(userlogindto);
        }


        private bool EqualsPassword(string password, string passwordHash, string passwordSalt)
        {
            using (var hmac = new HMACSHA512(Convert.FromBase64String(passwordSalt)))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(Convert.FromBase64String(passwordHash));
            }
        }

        private ClaimsIdentity GetIdentity(string email, string password)
        {
            // UserLogin person = _context.UserLogins.FirstOrDefault(x => x.Email == email && x.Password == password);
            UserLogin person = _context.UserLogins.Where(x => x.Email == email).FirstOrDefault();
            if (person != null && EqualsPassword(password, person.Password, person.Salt))
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