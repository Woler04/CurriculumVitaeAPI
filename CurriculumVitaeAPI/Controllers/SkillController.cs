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
        private readonly IResumeRepository _resumeRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

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
        public IActionResult CreateSkill([FromBody] SkillDto skillCreate)
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
            skillMap.SkillId = 0;

            if (!_skillRepository.CreateSkill(skillMap))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPost("{skillId}&&{resumeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult BindSkill(int skillId, int resumeId)
        {
            ResumeSkill resumeSkill = new()
            {
                ResumeId = resumeId,
                Resume = _resumeRepository.GetResume(resumeId),
                SkillId = skillId,
                Skill = _skillRepository.GetSkill(skillId)
            };

            if (_skillRepository.isBindExcsisting(resumeSkill))
            {
                ModelState.AddModelError("", "Already Excists");
                return StatusCode(422, ModelState);
            }

            if (!_skillRepository.BindSkill(resumeSkill))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully binded");
        }

        //UPDATE
        [HttpPut("{skillId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateSkill(int skillId, [FromBody] SkillDto skillUpdate)
        {
            if (skillUpdate == null)
            {
                return BadRequest();
            }

            if (!_skillRepository.isSkillExsisting(skillId))
            {
                return NotFound();
            }

            if (skillId != skillUpdate.SkillId)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var skillMap = _mapper.Map<Skill>(skillUpdate);

            if (!_skillRepository.UpdateSkill(skillMap))
            {
                ModelState.AddModelError("", "Can not update");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully updated");
        }

        [HttpDelete("{skillId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteSkill(int skillId)
        {
            if (!_skillRepository.isSkillExsisting(skillId))
            {
                return NotFound();
            }

            var skillDelete = _skillRepository.GetSkill(skillId);


            //delete if has any connections
            if (skillDelete.ResumeSkills != null)
            {
                var binds = skillDelete.ResumeSkills.ToList();
                foreach (var bind in binds)
                {
                    UnbindSkill((int)bind.SkillId, (int)bind.ResumeId);
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_skillRepository.DeleteSkill(skillDelete))
            {
                ModelState.AddModelError("", "Can not delete");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted");
        }

        [HttpDelete("{skillId}&&{resumeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UnbindSkill(int skillId, int resumeId)
        {
            ResumeSkill resumeSkill = _skillRepository.GetBind(skillId, resumeId);

            if (resumeSkill == null)
            {
                ModelState.AddModelError("", "Already Excists");
                return StatusCode(422, ModelState);
            }

            if (!_skillRepository.UnbindSkill(resumeSkill))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully binded");
        }
    }
}
