    using AutoMapper;
using CurriculumVitaeAPI.DTOs;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitaeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : Controller
    {
        ////////get

        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public ResumeController(IResumeRepository resumeRepository, IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _resumeRepository = resumeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Resume>))]
        public IActionResult GetResumes()
        {
            var resumes = _mapper.Map<List<ResumeDto>>(_resumeRepository.GetResumes());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(resumes);
        }

        [HttpGet("{resumeId}")]
        [ProducesResponseType(200, Type = typeof(Resume))]
        [ProducesResponseType(400)]
        public IActionResult GetResume(int resumeId)
        {
            if (!_resumeRepository.isResumeExsisting(resumeId))
            {
                return NotFound();
            }

            var resume = _mapper.Map<ResumeDto>(_resumeRepository.GetResume(resumeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(resume);
        }

        [HttpGet("{resumeId}/user")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUserByResume(int resumeId)
        {
            if (!_resumeRepository.isResumeExsisting(resumeId))
            {
                return NotFound();
            }

            var user = _mapper.Map<UserDto>(_resumeRepository.GetUserByResume(resumeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(user);
        }

        [HttpGet("{resumeId}/skills")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Skill>))]
        [ProducesResponseType(400)]
        public IActionResult GetResumeSkills(int resumeId)
        {
            if (!_resumeRepository.isResumeExsisting(resumeId))
            {
                return NotFound();
            }

            var skills = _mapper.Map<List<SkillDto>>(_resumeRepository.GetSkillsByResumeId(resumeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(skills);
        }

        [HttpGet("{resumeId}/template")]
        [ProducesResponseType(200, Type = typeof(Template))]
        [ProducesResponseType(400)]
        public IActionResult GetResumeTemplate(int resumeId)
        {
            if (!_resumeRepository.isResumeExsisting(resumeId))
            {
                return NotFound();
            }

            var template = _mapper.Map<TemplateDto>(_resumeRepository.GetTemplateByResumeId(resumeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(template);
        }

        [HttpGet("{resumeId}/locations")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Location>))]
        [ProducesResponseType(400)]
        public IActionResult GetResumeLocation(int resumeId)
        {
            if (!_resumeRepository.isResumeExsisting(resumeId))
            {
                return NotFound();
            }

            var locations = _mapper.Map<List<LocationDto>>(_resumeRepository.GetLocationByResumeId(resumeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(locations);
        }

        [HttpGet("{resumeId}/languages")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Location>))]
        [ProducesResponseType(400)]
        public IActionResult GetResumeLanguage(int resumeId)
        {
            if (!_resumeRepository.isResumeExsisting(resumeId))
            {
                return NotFound();
            }

            var language = _mapper.Map<List<LanguageDto>>(_resumeRepository.GetLanguageByResumeId(resumeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(language);
        }

        [HttpGet("{resumeId}/certificates")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Certificate>))]
        [ProducesResponseType(400)]
        public IActionResult GetResumeCertificates(int resumeId)
        {
            if (!_resumeRepository.isResumeExsisting(resumeId))
            {
                return NotFound();
            }

            var certificate = _mapper.Map<List<CertificateDto>>(_resumeRepository.GetCertificateByResumeId(resumeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(certificate);
        }
        [HttpGet("{resumeId}/personalInfo")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PersonalInfo>))]
        [ProducesResponseType(400)]
        public IActionResult GetResumePersonalInfos(int resumeId)
        {
            if (!_resumeRepository.isResumeExsisting(resumeId))
            {
                return NotFound();
            }

            var certificate = _mapper.Map<List<PersonalInfoDto>>(_resumeRepository.GetPersonalInfoByResumeId(resumeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(certificate);
        }

        [HttpGet("{resumeId}/educations")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Education>))]
        [ProducesResponseType(400)]
        public IActionResult GetResumeEducations(int resumeId)
        {
            if (!_resumeRepository.isResumeExsisting(resumeId))
            {
                return NotFound();
            }

            var certificate = _mapper.Map<List<EducationDto>>(_resumeRepository.GetEducationByResumeId(resumeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(certificate);
        }

        [HttpGet("{resumeId}/experiences")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Experience>))]
        [ProducesResponseType(400)]
        public IActionResult GetResumeExperiences(int resumeId)
        {
            if (!_resumeRepository.isResumeExsisting(resumeId))
            {
                return NotFound();
            }

            var certificate = _mapper.Map<List<ExperienceDto>>(_resumeRepository.GetExperienceByResumeId(resumeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(certificate);
        }

        ////////post
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateResume(int userId, [FromBody] ResumeDto resumeCreate)
        {
            if (resumeCreate == null)
            {
                return BadRequest();
            }

            var resume = _resumeRepository.GetResumes()
                .Where(r => r.Title.Trim().ToLower() == resumeCreate.Title.TrimEnd().ToLower() &&
                r.User == r.User).FirstOrDefault();

            if (resume != null)
            {
                ModelState.AddModelError("", "Already Excists with this title");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Resume resumeMap = _mapper.Map<Resume>(resumeCreate);

            if (!_resumeRepository.CreateResume(userId, resumeMap))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{resumeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateResume(int resumeId, [FromQuery] int userId, [FromBody] ResumeDto resumeUpdate)
        {
            if (resumeUpdate == null)
            {
                return BadRequest();
            }

            if (!_resumeRepository.isResumeExsisting(resumeId))
            {
                return NotFound();
            }

            if (resumeId != resumeUpdate.ResumeId)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var resumeMap = _mapper.Map<Resume>(resumeUpdate);
            resumeMap.UserId = userId;

            if (!_resumeRepository.UpdateResume(resumeMap))
            {
                ModelState.AddModelError("", "Can not update");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

    }
}
