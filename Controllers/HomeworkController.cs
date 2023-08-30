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

            return Ok(homework);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Homework))]
        [ProducesResponseType(400)]
        public IActionResult GetHomeworkById(int id)
        {
            var homework = _mapper.Map<HomeworkDto>(_homeworkRepository.GetHomeworkById(id));
            
            try
            {
                return Ok(homework);
            } catch(NotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/materials")]
        [ProducesResponseType(200, Type = typeof(string[]))]
        [ProducesResponseType(400)]
        public IActionResult GetMaterials(int id)
        {
            var materials = _mapper.Map<HomeworkDto>(_homeworkRepository.GetMaterials(id));

            try
            {
                return Ok(materials);
            } catch(NotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public IActionResult CreateLesson([FromBody] HomeworkDto homeworkCreate)
        {
            var homeworkMap = _mapper.Map<Homework>(homeworkCreate);

            _homeworkRepository.CreateHomework(homeworkMap);
            return Ok("Successfully created");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateHomework(int homeworkId, [FromBody] Homework updatedHomework)
        {
            var homeworkMap = _mapper.Map<Homework>(updatedHomework);

            _homeworkRepository.UpdateHomework(homeworkMap);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteHomework(int id)
        {
            var homeworkToDelete = _homeworkRepository.GetHomeworkById(id);

            _homeworkRepository.DeleteHomework(homeworkToDelete);

            return NoContent();
        }
    }
}
