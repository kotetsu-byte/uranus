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
    public class TestController : Controller
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestController(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Test>))]
        public IActionResult GetTests()
        {
            var tests = _mapper.Map<List<TestDto>>(_testRepository.GetTests());

            return Ok(tests);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Test))]
        [ProducesResponseType(400)]
        public IActionResult GetTestById(int id)
        {
            var test = _mapper.Map<TestDto>(_testRepository.GetTestById(id));

            try
            {
                return Ok(test);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(Test))]
        [ProducesResponseType(400)]
        public IActionResult CreateTest([FromBody] TestDto testCreate)
        {
            var testMap = _mapper.Map<Test>(testCreate);

            _testRepository.CreateTest(testMap);

            return Ok("Created Successfully");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTest([FromBody] TestDto updatedTest)
        {
            var testMap = _mapper.Map<Test>(updatedTest);

            _testRepository.UpdateTest(testMap);

            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTest(int id)
        {
            var testToDelete = _testRepository.GetTestById(id);

            _testRepository.DeleteTest(testToDelete);

            return Ok("Deleted Successfully");
        }
    }
}
