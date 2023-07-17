﻿    using AutoMapper;
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
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;
        public ResumeController(IResumeRepository resumeRepository, IMapper mapper)
        {
            this._resumeRepository = resumeRepository;
            this._mapper = mapper;
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
    }
}
