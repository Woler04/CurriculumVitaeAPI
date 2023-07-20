using AutoMapper;
using CurriculumVitaeAPI.DTOs;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitaeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : Controller
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public LanguageController(ILanguageRepository languageRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _resumeRepository = resumeRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Language>))]
        public IActionResult GetLanguages()
        {
            var languages = _mapper.Map<List<LanguageDto>>(_languageRepository.GetLanguages());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(languages);
        }

        [HttpGet("{languageId}")]
        [ProducesResponseType(200, Type = typeof(Language))]
        public IActionResult GetLanguage(int languageId)
        {
            if (!_languageRepository.isLanguageExcisting(languageId))
            {
                return NotFound();
            }

            var language = _mapper.Map<LanguageDto>(_languageRepository.GetLanguage(languageId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(language);
        }

        [HttpGet("/{languageId}/resumes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Resume>))]
        [ProducesResponseType(400)]
        public IActionResult GetResumesByLanguageId(int languageId)
        {
            var resumes = _mapper.Map<List<ResumeDto>>(_languageRepository.GetResumesByLanguage(languageId));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(resumes);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateLanguage([FromBody] LanguageDto languageCreate)
        {
            if (languageCreate == null)
            {
                return BadRequest();
            }

            var skill = _languageRepository.GetLanguages()
                .Where(r => r.LanguageName.Trim().ToLower() == languageCreate.LanguageName.TrimEnd().ToLower()).FirstOrDefault();

            if (skill != null)
            {
                ModelState.AddModelError("", "Already Excists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var languageMap = _mapper.Map<Language>(languageCreate);
            languageMap.LanguageId = 0;
            if (!_languageRepository.CreateLanguage(languageMap))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{languageId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateLanguage(int languageId, [FromBody] LanguageDto languageUpdate)
        {
            if (languageUpdate == null)
            {
                return BadRequest();
            }

            if (!_languageRepository.isLanguageExcisting(languageId))
            {
                return NotFound();
            }

            if (languageId != languageUpdate.LanguageId)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var languageMap = _mapper.Map<Language>(languageUpdate);

            if (!_languageRepository.UpdateLanguage(languageMap))
            {
                ModelState.AddModelError("", "Can not update");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }
       
        [HttpPost("{languageId}&&{resumeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult BindLanguage(int languageId, int resumeId)
        {
            ResumeLanguage resumeLanguage = new()
            {
                ResumeId = resumeId,
                Resume = _resumeRepository.GetResume(resumeId),
                LanguageId = languageId,
                Language = _languageRepository.GetLanguage(languageId)
            };

            if (_languageRepository.isBindExcsisting(resumeLanguage))
            {
                ModelState.AddModelError("", "Already Excists");
                return StatusCode(422, ModelState);
            }

            if (!_languageRepository.Bindlanguage(resumeLanguage))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully binded");
        }
    }
}
