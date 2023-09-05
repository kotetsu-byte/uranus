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
    public class VideoController : Controller
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public VideoController(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Video>))]
        public IActionResult GetVideos()
        {
            var videos = _mapper.Map<List<VideoDto>>(_videoRepository.GetVideos());

            return Ok(videos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Video))]
        [ProducesResponseType(400)]
        public IActionResult GetVideoById(int id)
        {
            var video = _mapper.Map<VideoDto>(_videoRepository.GetVideoById(id));

            try
            {
                return Ok(video);
            } catch(NotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(Video))]
        [ProducesResponseType(400)]
        public IActionResult CreateVideo([FromBody] VideoDto videoCreate)
        {
            var videoMap = _mapper.Map<Video>(videoCreate);

            _videoRepository.CreateVideo(videoMap);

            return Ok("Created Successfully");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateVideo([FromBody] VideoDto updatedVideo)
        {
            var videoMap = _mapper.Map<Video>(updatedVideo);

            _videoRepository.UpdateVideo(videoMap);

            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteVideo(int id)
        {
            var videoToDelete = _videoRepository.GetVideoById(id);

            _videoRepository.DeleteVideo(videoToDelete);

            return Ok("Deleted Successfully");
        }
    }
}
