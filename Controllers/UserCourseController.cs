using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uranus.Dto;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly IMapper _mapper;

        public UserCourseController(IUserCourseRepository userCourseRepository, IMapper mapper)
        {
            _userCourseRepository = userCourseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserCourses()
        {
            var userCourseDtos = _mapper.Map<UserCourseDto>(await _userCourseRepository.GetAllUserCourses());

            return Ok(userCourseDtos);
        }

        [HttpGet("{userId}/{courseId}")]
        public async Task<IActionResult> GetUserCourseById(int userId, int courseId)
        {
            var userCourseDto = _mapper.Map<UserCourseDto>(await _userCourseRepository.GetUserCourseById(userId, courseId));

            return Ok(userCourseDto);
        }

        [HttpPost]
        public IActionResult CreateUserCourse([FromBody] UserCourseDto userCourseDto)
        {
            var userCourse = _mapper.Map<UserCourse>(userCourseDto);

            _userCourseRepository.Create(userCourse);

            return Ok("Succeeded");
        }

        [HttpPut]
        public IActionResult UpdateUserCourse([FromBody] UserCourseDto userCourseDto)
        {
            if (!_userCourseRepository.Exists((int)userCourseDto.UserId, (int)userCourseDto.CourseId))
                return BadRequest("No such data");

            var userCourse = _mapper.Map<UserCourse>(userCourseDto);

            _userCourseRepository.Update(userCourse);

            return Ok("Succeeded");
        }

        [HttpDelete("{userId}/{courseId}")]
        public IActionResult DeleteUserCourse(int userId, int courseId)
        {
            if (!_userCourseRepository.Exists(userId, courseId))
                return BadRequest("No such data");

            _userCourseRepository.Delete(userId, courseId);

            return Ok("Succeeded");
        }
    }
}
