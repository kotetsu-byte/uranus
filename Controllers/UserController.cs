using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Uranus.Dto;
using Uranus.Exceptions;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            return Ok(_mapper.Map<List<UserDto>>(_userRepository.GetUsers()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUserById(int id)
        {
            try
            {
                return Ok(_mapper.Map<UserDto>(_userRepository.GetUserById(id)));
            } catch (NotFoundException ex) 
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] User userCreate)
        {
            var userMap = _mapper.Map<User>(userCreate);

            _userRepository.CreateUser(userMap);

            return Ok("Successfully created");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser([FromBody] UserDto updatedUser)
        {
            var userMap = _mapper.Map<User>(updatedUser);

            _userRepository.UpdateUser(userMap);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int id)
        {
            var userToDelete = _userRepository.GetUserById(id);

            _userRepository.DeleteUser(userToDelete);

            return NoContent();
        }
    }
}
