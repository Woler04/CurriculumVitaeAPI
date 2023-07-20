using AutoMapper;
using CurriculumVitaeAPI.DTOs;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitaeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : Controller
    {
        private IResumeRepository _resumeRepository;
        private ICertificateRepository _certificateRepository;
        private IMapper _mapper;

        public CertificateController(ICertificateRepository certificateRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _resumeRepository = resumeRepository;
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Certificate>))]
        public IActionResult GetExperiences()
        {
            var certificates = _mapper.Map<List<CertificateDto>>(_certificateRepository.GetCertificates());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(certificates);
        }

        [HttpGet("{certificateId}")]
        [ProducesResponseType(200, Type = typeof(Certificate))]
        [ProducesResponseType(400)]
        public IActionResult GetCertificate(int certificateId)
        {
            if (!_certificateRepository.isCertificateExcisting(certificateId))
            {
                return NotFound();
            }

            var certificate = _mapper.Map<CertificateDto>(_certificateRepository.GetCertificate(certificateId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(certificate);
        }

        [HttpGet("search/{keyword}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Resume>))]
        [ProducesResponseType(400)]
        public IActionResult GetResumesByKeyword(string keyword)
        {
            var resumes = _mapper.Map<List<ResumeDto>>(_certificateRepository.GetResumesByCertificateKeyword(keyword));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(resumes);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCertificate([FromQuery] int resumeId, [FromBody] CertificateDto certificateCreate)
        {
            if (certificateCreate == null)
            {
                return BadRequest();
            }

            var certificate = _certificateRepository.GetCertificates()
                .Where(r => r.CertificateName.Trim().ToLower() == certificateCreate.CertificateName.TrimEnd().ToLower() &&
                r.ResumeId == resumeId).FirstOrDefault();

            if (certificate != null)
            {
                ModelState.AddModelError("", "Already Excists in this resume");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var certificateMap = _mapper.Map<Certificate>(certificateCreate);
            certificateMap.Resume = _resumeRepository.GetResume(resumeId);
            certificate.CertificateId = 0;

            if (!_certificateRepository.CreateCertificate(certificateMap))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
        [HttpPut("{certificateId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCertificate(int certificateId, [FromQuery] int resumeId, [FromBody] CertificateDto certificateUpdate)
        {
            if (certificateUpdate == null)
            {
                return BadRequest();
            }

            if (!_certificateRepository.isCertificateExcisting(certificateId))
            {
                return NotFound();
            }

            if (certificateId != certificateUpdate.CertificateId)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            { 
                return BadRequest();
            }

            var certificateMap = _mapper.Map<Certificate>(certificateUpdate);
            certificateMap.ResumeId = resumeId;
            if (!_certificateRepository.UpdateCertificate(certificateMap))
            {
                ModelState.AddModelError("", "Can not update");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

        [HttpDelete("{certficateId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteCertificate(int certficateId)
        {
            if (!_certificateRepository.isCertificateExcisting(certficateId))
            {
                return NotFound();
            }

            var certificateDelete = _certificateRepository.GetCertificate(certficateId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_certificateRepository.DeleteCertificate(certificateDelete))
            {
                ModelState.AddModelError("", "Can not delete");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted");
        }
    }
}
