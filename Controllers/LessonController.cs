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
    public class LessonController : Controller
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public LessonController(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Lesson>))]
        public IActionResult GetLessons()
        {
            var lesson = _mapper.Map<List<LessonDto>>(_lessonRepository.GetLessons());

            return Ok(lesson);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Lesson))]
        [ProducesResponseType(400)]
        public IActionResult GetLessonById(int id)
        {
            var lesson = _mapper.Map<LessonDto>(_lessonRepository.GetLessonById(id));

            try
            {
                return Ok(lesson);
            } catch(NotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/videos")]
        [ProducesResponseType(200, Type = typeof(string[]))]
        [ProducesResponseType(400)]
        public IActionResult GetVideos(int id)
        {
            var videos = _mapper.Map<LessonDto>(_lessonRepository.GetVideos(id));

            try
            {
                return Ok(videos);
            } catch(NotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/docs")]
        [ProducesResponseType(200, Type = typeof(string[]))]
        [ProducesResponseType(400)]
        public IActionResult GetDocs(int id)
        {
            var docs = _mapper.Map<LessonDto>(_lessonRepository.GetDocs(id));

            try
            {
                return Ok(docs);
            } catch(NotFoundException ex) 
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public IActionResult CreateLesson([FromBody] LessonDto lessonCreate)
        {
            var lessonMap = _mapper.Map<Lesson>(lessonCreate);

            _lessonRepository.CreateLesson(lessonMap);
            
            return Ok("Successfully created");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateLesson(int lessonId, [FromBody] LessonDto updatedLesson)
        {
            var lessonMap = _mapper.Map<Lesson>(updatedLesson);

            _lessonRepository.UpdateLesson(lessonMap);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteLesson(int id)
        {
            var lessonToDelete = _lessonRepository.GetLessonById(id);

            _lessonRepository.DeleteLesson(lessonToDelete);

            return NoContent();
        }
    }
}
