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

        public EducationController(IEducationRepository educationRepository, IMapper mapper)
        {
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

        [HttpGet("educationId")]
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
    }
}
