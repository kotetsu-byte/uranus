using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uranus.Dto;
using Uranus.Interfaces;
using Uranus.Models;

namespace Uranus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public VideoController(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}/{lessonId}")]
        public async Task<IActionResult> GetAllVideos(int courseId, int lessonId)
        {
            var videoDtos = _mapper.Map<List<VideoDto>>(await _videoRepository.GetAllVideos(courseId, lessonId));

            return Ok(videoDtos);
        }

        [HttpGet("{courseId}/{lessonId}/{id}")]
        public async Task<IActionResult> GetVideoById(int courseId, int lessonId, int id)
        {
            var videoDto = _mapper.Map<VideoDto>(await _videoRepository.GetVideoById(courseId, lessonId, id));

            return Ok(videoDto);
        }

        [HttpPost]
        public IActionResult CreateVideo([FromBody] VideoPostDto videoDto, int courseId, int lessonId)
        {
            var video = _mapper.Map<Video>(videoDto);

            video.CourseId = courseId;
            video.LessonId = lessonId;

            _videoRepository.Create(video);

            return Ok("Succeeded");
        }

        [HttpPut]
        public IActionResult UpdateVideo([FromBody] VideoDto videoDto)
        {
            if (!_videoRepository.Exists((int)videoDto.CourseId, (int)videoDto.LessonId, (int)videoDto.Id))
                return BadRequest("No such data");

            var video = _mapper.Map<Video>(videoDto);

            _videoRepository.Update(video);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVideo(int id)
        {
            if (!_videoRepository.Exists(id))
                return BadRequest("No such data");

            _videoRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
