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
    public class DocController : Controller
    {
        private readonly IDocRepository _docRepository;
        private readonly IMapper _mapper;

        public DocController(IDocRepository docRepository, IMapper mapper)
        {
            _docRepository = docRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Doc>))]
        public IActionResult GetDocs()
        {
            var docs = _mapper.Map<List<DocDto>>(_docRepository.GetDocs());

            return Ok(docs);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Doc))]
        [ProducesResponseType(400)]
        public IActionResult GetDocById(int id)
        {
            var doc = _mapper.Map<DocDto>(_docRepository.GetDocById(id));

            try
            {
                return Ok(doc);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(Test))]
        [ProducesResponseType(400)]
        public IActionResult CreateTest([FromBody] DocDto docCreate)
        {
            var docMap = _mapper.Map<Doc>(docCreate);

            _docRepository.CreateDoc(docMap);

            return Ok("Created Successfully");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDoc([FromBody] DocDto updatedDoc)
        {
            var docMap = _mapper.Map<Doc>(updatedDoc);

            _docRepository.UpdateDoc(docMap);

            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDoc(int id)
        {
            var docToDelete = _docRepository.GetDocById(id);

            _docRepository.DeleteDoc(docToDelete);

            return Ok("Deleted Successfully");
        }
    }
}
