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

        [HttpPost("{courseId}")]
        public IActionResult CreateLesson([FromBody] LessonDto lessonDto, int courseId)
        {
            var lesson = _mapper.Map<Lesson>(lessonDto);

            lesson.CourseId = courseId;

            _lessonRepository.Create(lesson);

            return Ok("Succeeded");
        }

        [HttpPut]
        public IActionResult UpdateLesson([FromBody] LessonDto lessonDto)
        {
            var lesson = _mapper.Map<Lesson>(lessonDto);

            _lessonRepository.Update(lesson);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLesson(int id)
        {
            _lessonRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
