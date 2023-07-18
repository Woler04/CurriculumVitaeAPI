using AutoMapper;
using CurriculumVitaeAPI.DTOs;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace CurriculumVitaeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : Controller
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;
        public TemplateController(ITemplateRepository templateRepository, IMapper mapper)
        {
            this._templateRepository = templateRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Template>))]
        public IActionResult Gettemplates()
        {
            var templates = _mapper.Map<List<TemplateDto>>(_templateRepository.GetTemplates());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(templates);
        }

        [HttpGet("{templateId}")]
        [ProducesResponseType(200, Type = typeof(Template))]
        [ProducesResponseType(400)]
        public IActionResult GetTemplate(int templateId)
        {
            if (!_templateRepository.isTemplateExcisting(templateId))
            {
                return NotFound();
            }

            var template = _mapper.Map<TemplateDto>(_templateRepository.GetTemplate(templateId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(template);
        }

        [HttpGet("/{templateId}/resumes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Resume>))]
        [ProducesResponseType(400)]
        public IActionResult GetResumesByTemplateId(int templateId)
        {
            var resumes = _mapper.Map<List<ResumeDto>>(_templateRepository.GetResumesByTemplate(templateId));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(resumes);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTemplate([FromQuery] int resumeId, [FromBody] TemplateDto templateCreate)
        {
            if (templateCreate == null)
            {
                return BadRequest();
            }

            var skill = _templateRepository.GetTemplates()
                .Where(r => r.TemplateFilePath.Trim().ToLower() == templateCreate.TemplateFilePath.TrimEnd().ToLower() && r.TemplateName.Trim().ToLower() == templateCreate.TemplateName.TrimEnd().ToLower()).FirstOrDefault();

            if (skill != null)
            {
                ModelState.AddModelError("", "Already Excists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var templateMap = _mapper.Map<Template>(templateCreate);

            if (!_templateRepository.CreateTemplate(resumeId, templateMap))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
    }
}
