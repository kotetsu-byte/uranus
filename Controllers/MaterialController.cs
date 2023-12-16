using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uranus.Dto;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialController(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}/{lessonId}/{homeworkId}")]
        public async Task<IActionResult> GetAllMaterials(int courseId, int lessonId, int homeworkId)
        {
            var materialDtos = _mapper.Map<List<MaterialDto>>(await _materialRepository.GetAllMaterials(courseId, lessonId, homeworkId));

            return Ok(materialDtos);
        }

        [HttpGet("{courseId}/{lessonId}/{homeworkId}/{id}")]
        public async Task<IActionResult> GetMaterialById(int courseId, int lessonId, int homeworkId, int id)
        {
            var materialDto = _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialById(courseId, lessonId, homeworkId, id));

            return Ok(materialDto);
        }

        [HttpPost("{courseId}/{lessonId}/{homeworkId}")]
        public IActionResult CreateMaterial([FromBody] MaterialDto materialDto, int courseId, int lessonId, int homeworkId)
        {
            var material = _mapper.Map<Material>(materialDto);

            material.CourseId = courseId;
            material.LessonId = lessonId;
            material.HomeworkId = homeworkId;

            _materialRepository.Create(material);

            return Ok("Succeeded");
        }

        [HttpPut]
        public IActionResult UpdateMaterial([FromBody] MaterialDto materialDto)
        {
            var material = _mapper.Map<Material>(materialDto);

            _materialRepository.Update(material);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMaterial(int id)
        {
            _materialRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
