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
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        public LanguageController(ILanguageRepository languageRepository, IMapper mapper)
        {
            this._languageRepository = languageRepository;
            this._mapper = mapper;
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
        public IActionResult CreateLanguage([FromQuery] int resumeId, [FromBody] LanguageDto languageCreate)
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

            if (!_languageRepository.CreateLanguage(resumeId, languageMap))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
    }
}
