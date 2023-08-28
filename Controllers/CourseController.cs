using Microsoft.AspNetCore.Mvc;
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

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Course>))]
        public IActionResult GetCourses()
        {
            var course = _courseRepository.GetCourses();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(course);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Course))]
        [ProducesResponseType(400)]
        public IActionResult GetCourseById(int id)
        {
            if (!_courseRepository.CourseExists(id))
                return NotFound();

            var course = _courseRepository.GetCourseById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(course);
        }

        [HttpGet("{id}/tests")]
        [ProducesResponseType(200, Type = typeof(string[]))]
        [ProducesResponseType(400)]
        public IActionResult GetTests(int id)
        {
            var tests = _courseRepository.GetTests(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tests);
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public IActionResult CreateCourse([FromBody] Course courseCreate)
        {
            if (courseCreate == null)
                return BadRequest(ModelState);

            var user = _courseRepository.GetCourses()
                .Where(u => u.Id == courseCreate.Id)
                .FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "Course already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok("Successfully created");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCourse(int courseId, [FromBody] User updatedCourse)
        {
            if (updatedCourse == null)
                return BadRequest(ModelState);

            if (courseId != updatedCourse.Id)
                return BadRequest(ModelState);

            if (!_courseRepository.CourseExists(courseId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCourse(int id)
        {
            if (!_courseRepository.CourseExists(id))
                return NotFound();

            var courseToDelete = _courseRepository.GetCourseById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_courseRepository.DeleteCourse(courseToDelete))
                ModelState.AddModelError("", "Something went wrong deleting course");

            return NoContent();
        }
    }
}
