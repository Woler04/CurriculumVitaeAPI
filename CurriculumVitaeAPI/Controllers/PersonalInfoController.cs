using AutoMapper;
using CurriculumVitaeAPI.DTOs;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitaeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : Controller
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IPersonalInfoRepository _personalInfoRepository;
        private readonly IMapper _mapper;

        public PersonalInfoController(IPersonalInfoRepository personalInfoRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _resumeRepository = resumeRepository;
            _personalInfoRepository = personalInfoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PersonalInfo>))]
        public IActionResult GetPersonalInfos()
        {
            var personalInfos = _mapper.Map<List<PersonalInfoDto>>(_personalInfoRepository.GetPersonalInfos());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(personalInfos);
        }

        [HttpGet("personalInfoId")]
        [ProducesResponseType(200, Type = typeof(PersonalInfo))]
        public IActionResult GetPersonalInfo(int personalInfoId)
        {
            if (!_personalInfoRepository.isPersonalInfoExcisting(personalInfoId))
            {
                return NotFound();
            }

            var personalInfo = _mapper.Map<PersonalInfoDto>(_personalInfoRepository.GetPersonalInfo(personalInfoId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(personalInfo);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePersonalInfo([FromQuery] int resumeId, [FromBody] PersonalInfoDto personalInfoCreate)
        {
            if (personalInfoCreate == null)
            {
                return BadRequest();
            }

            var personalInfo = _personalInfoRepository.GetPersonalInfos()
                .Where(r => r.ResumeId == resumeId).FirstOrDefault();

            if (personalInfo != null)
            {
                ModelState.AddModelError("", "Only one Personal per Resume");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var personalInfoMap = _mapper.Map<PersonalInfo>(personalInfoCreate);
            personalInfoMap.Resume = _resumeRepository.GetResume(resumeId);
            personalInfoMap.PersonalinfoId = 0;

            if (!_personalInfoRepository.CreatePersonalInfo(personalInfoMap))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{personalInfoId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePersonalInfo(int personalInfoId,[FromQuery] int resumeId, [FromBody] PersonalInfoDto personalInfoUpdate)
        {
            if (personalInfoUpdate == null)
            {
                return BadRequest();
            }

            if (!_personalInfoRepository.isPersonalInfoExcisting(personalInfoId))
            {
                return NotFound();
            }

            if (personalInfoId != personalInfoUpdate.PersonalinfoId)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var personalInfoMap = _mapper.Map<PersonalInfo>(personalInfoUpdate);
            personalInfoMap.ResumeId = resumeId;

            if (!_personalInfoRepository.UpdatePersonalInfo(personalInfoMap))
            {
                ModelState.AddModelError("", "Can not update");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

        [HttpPut("{resumeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateResume(int resumeId, [FromBody] ResumeDto resumeUpdate)
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

            var resumeMap = _mapper.Map<Resume>(resumeUpdate);

            if (!_resumeRepository.UpdateResume(resumeMap))
            {
                ModelState.AddModelError("", "Can not update");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

    }
}
