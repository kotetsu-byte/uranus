using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uranus.Dto;
using Uranus.Interfaces;
using Uranus.Models;
using Uranus.Repository;

namespace Uranus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : Controller
    {
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly IMapper _mapper;

        public HomeworkController(IHomeworkRepository homeworkRepository, IMapper mapper)
        {
            _homeworkRepository = homeworkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Homework>))]
        public IActionResult GetHomework()
        {
            var homework = _mapper.Map<List<HomeworkDto>>(_homeworkRepository.GetHomeworks());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(homework);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Homework))]
        [ProducesResponseType(400)]
        public IActionResult GetHomeworkById(int id)
        {
            if (!_homeworkRepository.HomeworkExists(id))
                return NotFound();

            var homework = _mapper.Map<HomeworkDto>(_homeworkRepository.GetHomeworkById(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(homework);
        }

        [HttpGet("{id}/materials")]
        [ProducesResponseType(200, Type = typeof(string[]))]
        [ProducesResponseType(400)]
        public IActionResult GetMaterials(int id)
        {
            var materials = _mapper.Map<HomeworkDto>(_homeworkRepository.GetMaterials(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(materials);
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public IActionResult CreateLesson([FromBody] HomeworkDto homeworkCreate)
        {
            if (homeworkCreate == null)
                return BadRequest(ModelState);

            var user = _homeworkRepository.GetHomeworks()
                .Where(u => u.Id == homeworkCreate.Id)
                .FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "Lesson already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var homeworkMap = _mapper.Map<Homework>(homeworkCreate);

            if (!_homeworkRepository.CreateHomework(homeworkMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving homework");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateHomework(int homeworkId, [FromBody] Homework updatedHomework)
        {
            if (updatedHomework == null)
                return BadRequest(ModelState);

            if (homeworkId != updatedHomework.Id)
                return BadRequest(ModelState);

            if (!_homeworkRepository.HomeworkExists(homeworkId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var homeworkMap = _mapper.Map<Homework>(updatedHomework);

            if (!_homeworkRepository.UpdateHomework(homeworkMap))
            {
                ModelState.AddModelError("", "Something went wrong while upading lesson");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteHomework(int id)
        {
            if (!_homeworkRepository.HomeworkExists(id))
                return NotFound();

            var homeworkToDelete = _homeworkRepository.GetHomeworkById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_homeworkRepository.DeleteHomework(homeworkToDelete))
                ModelState.AddModelError("", "Something went wrong deleting homework");

            return NoContent();
        }
    }
}
