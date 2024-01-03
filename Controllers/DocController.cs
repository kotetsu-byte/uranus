using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uranus.Dto;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocController : ControllerBase
    {
        private readonly IDocRepository _docRepository;
        private readonly IMapper _mapper;

        public DocController(IDocRepository docRepository, IMapper mapper)
        {
            _docRepository = docRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}/{lessonId}")]
        public async Task<IActionResult> GetAllDocs(int courseId, int lessonId)
        {
            var docDtos = _mapper.Map<List<DocDto>>(await _docRepository.GetAllDocs(courseId, lessonId));

            return Ok(docDtos);
        }

        [HttpGet("{courseId}/{lessonId}/{id}")]
        public async Task<IActionResult> GetDocById(int courseId, int lessonId, int id)
        {
            var docDto = _mapper.Map<DocDto>(await _docRepository.GetDocById(courseId, lessonId, id));
            
            return Ok(docDto);
        }

        [HttpPost]
        public IActionResult CreateTest([FromBody] DocPostDto docDto)
        {
            var doc = _mapper.Map<Doc>(docDto);

            _docRepository.Create(doc);

            return Ok("Succeeded");
        }

        [HttpPut]
        public IActionResult UpdateDoc([FromBody] DocDto docDto)
        {
            if (!_docRepository.Exists((int)docDto.CourseId, (int)docDto.LessonId, (int)docDto.Id))
                return BadRequest("No such data");
            
            var doc = _mapper.Map<Doc>(docDto);

            _docRepository.Update(doc);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoc(int id)
        {
            if (!_docRepository.Exists(id))
                return BadRequest("No such data");

            _docRepository.Delete(id);

            return Ok("Succeeded`");
        }
    }
}
