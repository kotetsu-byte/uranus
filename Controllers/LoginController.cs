using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Uranus.Dto;
using Uranus.Interfaces;
using Uranus.Models;
using Uranus.Repository;

namespace Uranus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        public static Login obj = new Login();
        private readonly IConfiguration _config;
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        public LoginController(IConfiguration config)
        {
            _config = config;   
        }

        [HttpPost("register")]
        public ActionResult<Login> Register(LoginDto request)
        {
            string password
                = BCrypt.Net.BCrypt.HashPassword(request.Password);

            obj.Username = request.Username;
            obj.Password = password;
            
            var loginMap = _mapper.Map<Login>(obj);

            _loginRepository.CreateLogin(loginMap);

            return Ok(obj);
        }

        [HttpPost("login")]
        public ActionResult<Login> Login(LoginDto request)
        {
            if(obj.Username != request.Username)
            {
                return BadRequest("User not found");
            }

            if(!BCrypt.Net.BCrypt.Verify(request.Password, obj.Password))
            {
                return BadRequest("Wrong password");
            }

            string token = CreateToken(obj);

            return Ok(token);
        }

        private string CreateToken(Login login)
        {
            List<Claim> claims = new List<Claim> 
            { 
                new Claim(ClaimTypes.Name, obj.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds 
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Login>))]
        public IActionResult GetLogins()
        {
            return Ok(_mapper.Map<List<LoginDto>>(_loginRepository.GetLogins()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Login))]
        [ProducesResponseType(400)]
        public IActionResult GetLoginById(int id)
        {
            try
            {
                return Ok(_mapper.Map<LoginDto>(_loginRepository.GetLoginById(id)));
            } catch(Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateLogin([FromBody] LoginDto updatedLogin)
        {
            var loginMap = _mapper.Map<Login>(updatedLogin);

            _loginRepository.UpdateLogin(loginMap);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int id)
        {
            var loginToDelete = _loginRepository.GetLoginById(id);

            _loginRepository.DeleteLogin(loginToDelete);

            return NoContent();
        }
    }
}
