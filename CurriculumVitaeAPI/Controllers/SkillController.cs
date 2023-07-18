using AutoMapper;
using CurriculumVitaeAPI.DTOs;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitaeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : Controller
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        private readonly IResumeRepository _resumeRepository;

        public SkillController(ISkillRepository skillRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _resumeRepository = resumeRepository;
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Skill>))]
        public IActionResult GetSkills()
        {
            var skills = _mapper.Map<List<SkillDto>>(_skillRepository.GetSkills());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(skills);
        }

        [HttpGet("{skillId}")]
        [ProducesResponseType(200, Type = typeof(Skill))]
        [ProducesResponseType(400)]
        public IActionResult GetSkill(int skillId)
        {
            if (!_skillRepository.isSkillExsisting(skillId))
            {
                return NotFound();
            }

            var skill = _mapper.Map<SkillDto>(_skillRepository.GetSkill(skillId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(skill);
        }

        [HttpGet("{skillId}/resumes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Resume>))]
        [ProducesResponseType(400)]
        public IActionResult GetResumesBySkillId(int skillId)
        {
            var resumes = _mapper.Map<List<ResumeDto>>(_skillRepository.GetResumesBySkillId(skillId));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(resumes);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateSkill([FromQuery] int resumeId, [FromBody] SkillDto skillCreate)
        {
            if (skillCreate == null)
            {
                return BadRequest();
            }

            var skill = _skillRepository.GetSkills()
                .Where(r => r.SkillName.Trim().ToLower() == skillCreate.SkillName.TrimEnd().ToLower()).FirstOrDefault();

            if (skill != null)
            {
                ModelState.AddModelError("", "Already Excists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var skillMap = _mapper.Map<Skill>(skillCreate);

            if (!_skillRepository.CreateSkill(resumeId, skillMap))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
    }
}
