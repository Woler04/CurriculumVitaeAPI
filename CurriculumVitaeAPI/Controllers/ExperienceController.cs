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
        private IResumeRepository _resumeRepository;
        private IExperienceRepository _experienceRepository;
        private IMapper _mapper;

        public ExperienceController(IExperienceRepository experiencerepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _resumeRepository = resumeRepository;
            _experienceRepository = experiencerepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Experience>))]
        public IActionResult GetExperiences()
        {
            var experiences = _mapper.Map<List<ExperienceDto>>(_experienceRepository.GetExperiences());

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
            if (!_experienceRepository.isExperienceExcisting(experienceId))
            {
                return NotFound();
            }

            var experience = _mapper.Map<ExperienceDto>(_experienceRepository.GetExperience(experienceId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(experience);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateExperience([FromQuery] int resumeId, [FromBody] ExperienceDto experienceCreate)
        {
            if (experienceCreate == null)
            {
                return BadRequest();
            }

            //var certificate = _experiencerepository.GetExperiences()
            //    .Where(r => r..Trim().ToLower() == educationCreate.FieldOfStudy.TrimEnd().ToLower() &&
            //    r.InstitutionName.Trim().ToLower() == educationCreate.InstitutionName.TrimEnd().ToLower() &&
            //    r.ResumeId == resumeId).FirstOrDefault();

            //if (certificate != null)
            //{
            //    ModelState.AddModelError("", "Already Excists in this resume");
            //    return StatusCode(422, ModelState);
            //}

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}

            var experienceMap = _mapper.Map<Experience>(experienceCreate);
            experienceMap.Resume = _resumeRepository.GetResume(resumeId);
            experienceMap.ExperienceId = 0;

            if (!_experienceRepository.CreateExperience(experienceMap))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
    }
}
