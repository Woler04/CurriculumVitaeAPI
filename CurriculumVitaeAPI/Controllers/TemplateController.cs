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

        [HttpGet("resumes/{templateId}")]
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

        [HttpGet("resumes")]
        [ProducesResponseType(404)]
        public IActionResult MissingArgument()
        {
            return NotFound("try api/template/resumes/id");
        }
    }
}
