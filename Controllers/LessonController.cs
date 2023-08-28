using Microsoft.AspNetCore.Mvc;
using Uranus.Interfaces;
using Uranus.Models;
using Uranus.Repository;

namespace Uranus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : Controller
    {
        private ILessonRepository _lessonRepository;

        public LessonController(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Lesson>))]
        public IActionResult GetLessons()
        {
            var lesson = _lessonRepository.GetLessons();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(lesson);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Lesson))]
        [ProducesResponseType(400)]
        public IActionResult GetLessonById(int id)
        {
            if (!_lessonRepository.LessonExists(id))
                return NotFound();

            var lesson = _lessonRepository.GetLessonById(id);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(lesson);
        }

        [HttpGet("{id}/videos")]
        [ProducesResponseType(200, Type = typeof(string[]))]
        [ProducesResponseType(400)]
        public IActionResult GetVideos(int id)
        {
            var videos = _lessonRepository.GetVideos(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(videos);
        }

        [HttpGet("{id}/docs")]
        [ProducesResponseType(200, Type = typeof(string[]))]
        [ProducesResponseType(400)]
        public IActionResult GetDocs(int id)
        {
            var docs = _lessonRepository.GetDocs(id);
            
            if(!ModelState.IsValid)
                return BadRequest();
        
            return Ok(docs);
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public IActionResult CreateLesson([FromBody] Lesson lessonCreate)
        {
            
            if (lessonCreate == null)
                return BadRequest(ModelState);

            var user = _lessonRepository.GetLessons()
                .Where(u => u.Id == lessonCreate.Id)
                .FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "Lesson already exists");
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
        public IActionResult UpdateLesson(int lessonId, [FromBody] Lesson updatedLesson)
        {
            if (updatedLesson == null)
                return BadRequest(ModelState);

            if (lessonId != updatedLesson.Id)
                return BadRequest(ModelState);

            if (!_lessonRepository.LessonExists(lessonId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteLesson(int id)
        {
            if (!_lessonRepository.LessonExists(id))
                return NotFound();

            var lessonToDelete = _lessonRepository.GetLessonById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_lessonRepository.DeleteLesson(lessonToDelete))
                ModelState.AddModelError("", "Something went wrong deleting lesson");

            return NoContent();
        }
    }
}
