using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Uranus.Dto;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserController(IUserRepository userRepository, IMapper mapper, IConfiguration config)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(_mapper.Map<List<UserDto>>(await _userRepository.GetAllUsers()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(_mapper.Map<UserDto>(await _userRepository.GetUserById(id)));
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserPostDto userDto)
        {
            if(userDto.Password != userDto.ConfirmPassword)
            {
                return BadRequest("Passwords do not match");
            }
            
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            User user = new User();
            user.Username = userDto.Username;
            user.Password = passwordHash;

            _userRepository.Create(user);

            return Ok("Succeeded");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByUsername(loginDto.Username);

            if(user == null)
            {
                return BadRequest("User was not found");
            }

            if(!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return BadRequest("Wrong password");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value!)    
            );

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserDto userDto)
        {
            if (!_userRepository.Exists((int)userDto.Id))
                return BadRequest("No such data");

            var user = _mapper.Map<User>(userDto);

            _userRepository.Update(user);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (!_userRepository.Exists(id))
                return BadRequest("No such data");

            _userRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
