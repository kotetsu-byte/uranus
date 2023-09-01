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
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public LoginController(IConfiguration configuration, ILoginRepository loginRepository, IMapper mapper)
        {
            _config = configuration;
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] LoginDto request)
        {    
            var loginMap = _mapper.Map<Login>(request);

            _loginRepository.CreateLogin(loginMap);

            return Ok(loginMap);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto request)
        {
            var token = _mapper.Map<Login>(request);

            CreateToken(token);

            return Ok(token);
        }

        private string CreateToken(Login login)
        {
            List<Claim> claims = new List<Claim> 
            { 
                new Claim(ClaimTypes.Name, login.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

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
                return Ok(_mapper.Map<LoginDto>(_loginRepository.GetLoginById(id)));
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