using AutoMapper;
using CurriculumVitaeAPI.DTOs;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitaeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationController(ILocationRepository locationRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _resumeRepository = resumeRepository;
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Location>))]
        public IActionResult GetLocations()
        {
            var locations = _mapper.Map<List<LocationDto>>(_locationRepository.GetLocations());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(locations);
        }

        [HttpGet("{locationId}")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public IActionResult GetLocation(int locationId)
        {
            if (!_locationRepository.isLocationExcisting(locationId))
            {
                return NotFound();
            }

            var location = _mapper.Map<LocationDto>(_locationRepository.GetLocation(locationId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(location);
        }

        [HttpGet("/search/{keyword}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Resume>))]
        [ProducesResponseType(400)]
        public IActionResult GetResumesByKeyword(string keyword)
        {
            var resumes = _mapper.Map<List<ResumeDto>>(_locationRepository.GetResumesByKeyword(keyword));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(resumes);
        }

        [HttpGet("{locationId}/resumes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Resume>))]
        [ProducesResponseType(400)]
        public IActionResult GetResumesByKLocation(int locationId)
        {
            var resumes = _mapper.Map<List<ResumeDto>>(_locationRepository.GetResumesByLocation(locationId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(resumes);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateLocation([FromBody] LocationDto locationCreate)
        {
            if (locationCreate == null)
            {
                return BadRequest();
            }

            var skill = _locationRepository.GetLocations()
                .Where(r => r.City.Trim().ToLower() == locationCreate.City.TrimEnd().ToLower() && r.State.Trim().ToLower() == locationCreate.State.TrimEnd().ToLower() && r.Country.Trim().ToLower() == locationCreate.Country.TrimEnd().ToLower()).FirstOrDefault();

            if (skill != null)
            {
                ModelState.AddModelError("", "Already Excists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var locationMap = _mapper.Map<Location>(locationCreate);
            locationMap.LocationId = 0;
            if (!_locationRepository.CreateLocation(locationMap))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
        [HttpPost("{locationId}&&{resumeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult BindLocation(int locationId, int resumeId)
        {
            ResumeLocation resumeLocation = new()
            {
                ResumeId = resumeId,
                Resume = _resumeRepository.GetResume(resumeId),
                LocationId = locationId,
                Location = _locationRepository.GetLocation(locationId)
            };

            if (_locationRepository.isBindExcsisting(resumeLocation))
            {
                ModelState.AddModelError("", "Already Excists");
                return StatusCode(422, ModelState);
            }

            if (!_locationRepository.BindLocation(resumeLocation))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully binded");
        }
    }
}
