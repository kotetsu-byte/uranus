using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uranus.Dto;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public LessonController(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetAllLessons(int courseId)
        {
            var lessonDtos = _mapper.Map<List<LessonDto>>(await _lessonRepository.GetAllLessons(courseId));

            return Ok(lessonDtos);
        }

        [HttpGet("{courseId}/{id}")]
        public async Task<IActionResult> GetLessonById(int courseId, int id)
        {
            var lessonDto = _mapper.Map<LessonDto>(await _lessonRepository.GetLessonById(courseId, id));

            return Ok(lessonDto);
        }

        [HttpPost]
        public IActionResult CreateLesson([FromBody] LessonPostDto lessonDto)
        {
            var lesson = _mapper.Map<Lesson>(lessonDto);

            _lessonRepository.Create(lesson);

            return Ok("Succeeded");
        }

        [HttpPut]
        public IActionResult UpdateLesson([FromBody] LessonDto lessonDto)
        {
            if (!_lessonRepository.Exists((int)lessonDto.CourseId, (int)lessonDto.Id))
                return BadRequest("No such data");

            var lesson = _mapper.Map<Lesson>(lessonDto);

            _lessonRepository.Update(lesson);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLesson(int id)
        {
            if (!_lessonRepository.Exists(id)) 
                return BadRequest("No such data");

            _lessonRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
