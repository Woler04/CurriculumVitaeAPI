using AutoMapper;
using CurriculumVitaeAPI.DTOs;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitaeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : Controller
    {
        private IExperienceRepository _experiencerepository;
        private IMapper _mapper;

        public ExperienceController(IExperienceRepository experiencerepository, IMapper mapper)
        {
            _experiencerepository = experiencerepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Experience>))]
        public IActionResult GetExperiences()
        {
            var experiences = _mapper.Map<List<ExperienceDto>>(_experiencerepository.GetExperiences());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(experiences);
        }

        [HttpGet("{experienceId}")]
        [ProducesResponseType(200, Type = typeof(Experience))]
        [ProducesResponseType(400)]
        public IActionResult GetResume(int experienceId)
        {
            if (!_experiencerepository.isExperienceExcisting(experienceId))
            {
                return NotFound();
            }

            var experience = _mapper.Map<ExperienceDto>(_experiencerepository.GetExperience(experienceId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(experience);
        }
    }
}
