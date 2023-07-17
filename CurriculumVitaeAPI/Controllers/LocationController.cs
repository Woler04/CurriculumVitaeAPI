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
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationController(ILocationRepository locationRepository, IMapper mapper)
        {
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

        [HttpGet("resumes/search/{keyword}")]
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

        [HttpGet("resumes/{locationId}")]
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

        [HttpGet("resumes")]
        [ProducesResponseType(404)]
        public IActionResult MissingArgument()
        {
            return NotFound("try api/Location/resumes/Id");
        }
    }
}
