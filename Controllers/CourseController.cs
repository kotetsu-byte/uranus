using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uranus.Dto;
using Uranus.Exceptions;
using Uranus.Interfaces;
using Uranus.Models;
using Uranus.Repository;

namespace Uranus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Course>))]
        public IActionResult GetCourses()
        {
            var course = _mapper.Map<List<CourseDto>>(_courseRepository.GetCourses());

            return Ok(course);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Course))]
        [ProducesResponseType(400)]
        public IActionResult GetCourseById(int id)
        {
            var course = _mapper.Map<CourseDto>(_courseRepository.GetCourseById(id));
            try
            {
                return Ok(course);
            }catch(NotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/tests")]
        [ProducesResponseType(200, Type = typeof(string[]))]
        [ProducesResponseType(400)]
        public IActionResult GetTests(int id)
        {
            try
            {
                var tests = _mapper.Map<CourseDto>(_courseRepository.GetTests(id));

                return Ok(tests);
            }catch (NotFoundException ex) 
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public IActionResult CreateCourse([FromBody] CourseDto courseCreate)
        {
            var courseMap = _mapper.Map<Course>(courseCreate);

            _courseRepository.CreateCourse(courseMap);

            return Ok("Successfully created");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCourse(int courseId, [FromBody] UserDto updatedCourse)
        {
            var courseMap = _mapper.Map<Course>(updatedCourse);

            _courseRepository.UpdateCourse(courseMap);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCourse(int id)
        {
            var courseToDelete = _courseRepository.GetCourseById(id);

            _courseRepository.DeleteCourse(courseToDelete);
            
            return NoContent();
        }
    }
}
