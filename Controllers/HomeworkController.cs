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
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly IMapper _mapper;

        public HomeworkController(IHomeworkRepository homeworkRepository, IMapper mapper)
        {
            _homeworkRepository = homeworkRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}/{lessonId}")]
        public async Task<IActionResult> GetAllHomeworks(int courseId, int lessonId)
        {
            var homeworkDtos = _mapper.Map<List<HomeworkDto>>(await _homeworkRepository.GetAllHomeworks(courseId, lessonId));

            return Ok(homeworkDtos);
        }

        [HttpGet("{courseId}/{lessonId}/{id}")]
        public async Task<IActionResult> GetHomeworkById(int courseId, int lessonId, int id)
        {
            var homeworkDto = _mapper.Map<HomeworkDto>(await _homeworkRepository.GetHomeworkById(courseId, lessonId, id));
            
            return Ok(homeworkDto);
        }

        [HttpPost]
        public IActionResult CreateLesson([FromBody] HomeworkPostDto homeworkDto)
        {
            var homework = _mapper.Map<Homework>(homeworkDto);

            _homeworkRepository.Create(homework);
            return Ok("Succeeded");
        }

        [HttpPut]
        public IActionResult UpdateHomework([FromBody] HomeworkDto homeworkDto)
        {
            if (!_homeworkRepository.Exists((int)homeworkDto.CourseId, (int)homeworkDto.LessonId, (int)homeworkDto.Id))
                return BadRequest("No such data");

            var homework = _mapper.Map<Homework>(homeworkDto);

            _homeworkRepository.Update(homework);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHomework(int id)
        {
            if (!_homeworkRepository.Exists(id))
                return BadRequest("No such data");
            
            _homeworkRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
