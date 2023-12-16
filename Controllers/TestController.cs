using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uranus.Dto;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestController(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetAllTests(int courseId)
        {
            var testDtos = _mapper.Map<List<TestDto>>(await _testRepository.GetAllTests(courseId));

            return Ok(testDtos);
        }

        [HttpGet("{courseId}/{id}")]
        public async Task<IActionResult> GetTestById(int courseId, int id)
        {
            var testDto = _mapper.Map<TestDto>(await _testRepository.GetTestById(courseId, id));

            return Ok(testDto);
        }

        [HttpPost("{courseId}")]
        public IActionResult CreateTest([FromBody] TestDto testDto, int courseId)
        {
            var test = _mapper.Map<Test>(testDto);

            test.CourseId = courseId;

            _testRepository.Create(test);

            return Ok("Succeeded");
        }

        [HttpPut]
        public IActionResult UpdateTest([FromBody] TestDto testDto)
        {
            var test = _mapper.Map<Test>(testDto);

            _testRepository.Update(test);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTest(int id)
        {
            _testRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
