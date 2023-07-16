using AutoMapper;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitaeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : Controller
    {
        private readonly IPersonalInfoRepository _personalInfoRepository;
        private readonly IMapper _mapper;

        public PersonalInfoController(IPersonalInfoRepository personalInfoRepository, IMapper mapper)
        {
            _personalInfoRepository = personalInfoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PersonalInfo>))]
        public IActionResult GetPersonalInfos()
        {
            var personalInfos = _mapper.Map<List<PersonalInfo>>(_personalInfoRepository.GetPersonalInfos());

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

            var personalInfo = _mapper.Map<PersonalInfo>(_personalInfoRepository.GetPersonalInfo(personalInfoId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(personalInfo);
        }
    }
}
