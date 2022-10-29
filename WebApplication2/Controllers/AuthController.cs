using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Server.Data;
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

        // public AuthController(DataContext context)
        // {
        //     _context = context;
        // }


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterRequest request)
        {
            if (_context.Users.Any(x => x.Email == request.Email))
            {
                return Unauthorized("User already exist.");
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken()
            };


            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            return Ok("User created.");
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == request.Email);

            if (user == null)
            {
                return Unauthorized("Invalid email.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized("Invalid password.");
            }

            if (user.VerifiedAt == null)
            {
                return Unauthorized("User is not verified.");
            }


            return Ok($"{user.Email} is logged in.");
        }

        [HttpPost("verify")]
        public async Task<IActionResult> Verify(string token)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.VerificationToken == token);

            if (user == null)
            {
                return Unauthorized("Invalid token.");
            }

            user.VerifiedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok($"User {user.Email} is verified!");
        }

        //method getToken returns token
        [HttpPost("token")]
        public async Task<IActionResult> GetToken(UserLoginRequest request)
        {
            var token = CreateRandomToken();

            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == request.Email);

            if (user == null)
            {
                return Unauthorized("Invalid email.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized("Invalid password.");
            }

            if (user.VerifiedAt == null)
            {
                return Unauthorized("User is not verified.");
            }

            return Ok(token);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}