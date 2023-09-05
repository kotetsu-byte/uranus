using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uranus.Dto;
using Uranus.Exceptions;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialController(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Material>))]
        public IActionResult GetMaterials()
        {
            var materials = _mapper.Map<List<MaterialDto>>(_materialRepository.GetMaterials());

            return Ok(materials);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Material))]
        [ProducesResponseType(400)]
        public IActionResult GetMaterialById(int id)
        {
            var material = _mapper.Map<MaterialDto>(_materialRepository.GetMaterialById(id));

            try
            {
                return Ok(material);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(Material))]
        [ProducesResponseType(400)]
        public IActionResult CreateMaterial([FromBody] MaterialDto materialCreate)
        {
            var materialMap = _mapper.Map<Material>(materialCreate);

            _materialRepository.CreateMaterial(materialMap);

            return Ok("Created Successfully");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateMaterial([FromBody] MaterialDto updatedMaterial)
        {
            var materialMap = _mapper.Map<Material>(updatedMaterial);

            _materialRepository.UpdateMaterial(materialMap);

            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteMaterial(int id)
        {
            var materialToDelete = _materialRepository.GetMaterialById(id);

            _materialRepository.DeleteMaterial(materialToDelete);

            return Ok("Deleted Successfully");
        }
    }
}
