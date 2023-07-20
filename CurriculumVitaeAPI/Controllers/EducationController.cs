using AutoMapper;
using CurriculumVitaeAPI.DTOs;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitaeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : Controller
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;
        private readonly IResumeRepository _resumeRepository;

        public EducationController(IEducationRepository educationRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _resumeRepository = resumeRepository;
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Education>))]
        public IActionResult GetEducations()
        {
            var educations = _mapper.Map<List<EducationDto>>(_educationRepository.GetEducations());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(educations);
        }

        [HttpGet("{educationId}")]
        [ProducesResponseType(200, Type = typeof(Education))]
        public IActionResult GetEducation(int educationId)
        {
            if (!_educationRepository.isEducationExcisting(educationId))
            {
                return NotFound();
            }

            var education = _mapper.Map<EducationDto>(_educationRepository.GetEducation(educationId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(education);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEducation([FromQuery] int resumeId, [FromBody] EducationDto educationCreate)
        {
            if (educationCreate == null)
            {
                return BadRequest();
            }

            var certificate = _educationRepository.GetEducations()
                .Where(r => r.FieldOfStudy.Trim().ToLower() == educationCreate.FieldOfStudy.TrimEnd().ToLower() &&
                r.InstitutionName.Trim().ToLower() == educationCreate.InstitutionName.TrimEnd().ToLower() &&
                r.ResumeId == resumeId).FirstOrDefault();

            if (certificate != null)
            {
                ModelState.AddModelError("", "Already Excists in this resume");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var educationMap = _mapper.Map<Education>(educationCreate);
            educationMap.Resume = _resumeRepository.GetResume(resumeId);
            educationMap.EducationId = 0;

            if (!_educationRepository.CreateEducation(educationMap))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{educationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEducation(int educationId, [FromQuery] int resumeId, [FromBody] EducationDto educationUpdate)
        {
            if (educationUpdate == null)
            {
                return BadRequest();
            }

            if (!_educationRepository.isEducationExcisting(educationId))
            {
                return NotFound();
            }

            if (educationId != educationUpdate.EducationId)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            { 
                return BadRequest();
            }

            var educationMap = _mapper.Map<Education>(educationUpdate);
            educationMap.ResumeId = resumeId;

            if (!_educationRepository.UpdateEducation(educationMap))
            {
                ModelState.AddModelError("", "Can not update");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

        [HttpDelete("{educationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEducation(int educationId)
        {
            if (!_educationRepository.isEducationExcisting(educationId))
            {
                return NotFound();
            }

            var educationDelete = _educationRepository.GetEducation(educationId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_educationRepository.DeleteEducation(educationDelete))
            {
                ModelState.AddModelError("", "Can not delete");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted");
        }

    }
}
