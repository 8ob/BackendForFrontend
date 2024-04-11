using BackendForFrontend.Models;
using BackendForFrontend.Models.EFModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static BackendForFrontend.Models.DTOs.BlogDto;

namespace BackendForFrontend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtSettings _jwtSettings;

        public AuthController(AppDbContext context, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(e => e.Email == loginDto.Email);

            if (employee == null || employee.Password != loginDto.Password)
                return BadRequest("Invalid credentials");

            var token = GenerateJwtToken(employee);
            return Ok(new { Token = token });
        }

        [HttpPost("login/member")]
        public async Task<IActionResult> LoginMember(LoginDto loginDto)
        {
            var member = await _context.Members.SingleOrDefaultAsync(m => m.Email == loginDto.Email);

            if (member == null || member.Password != loginDto.Password)
                return BadRequest("Invalid credentials");

            var token = GenerateJwtTokenForMember(member);
            return Ok(new { Token = token });
        }

        private string GenerateJwtTokenForMember(Member member)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, member.Id.ToString()),
        new Claim(ClaimTypes.Email, member.Email),
        new Claim(ClaimTypes.Role, "Member")
    };

            // Generate the token using the same approach as for employees
            // ...
            return string.Join(" ", claims);
        }

        private string GenerateJwtToken(Employee employee)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
            new Claim(ClaimTypes.Email, employee.Email),
            new Claim(ClaimTypes.Role, "Employee")
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes);

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
