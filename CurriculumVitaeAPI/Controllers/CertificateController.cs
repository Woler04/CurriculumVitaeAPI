﻿using AutoMapper;
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
        private ICertificateRepository _certificateRepository;
        private IMapper _mapper;

        public CertificateController(ICertificateRepository certificateRepository, IMapper mapper)
        {
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

        [HttpGet("resumes/{keyword}")]
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

        [HttpGet("resumes")]
        [ProducesResponseType(404)]
        public IActionResult MissingArgument()
        {
            return NotFound( "try api/certificate/resumes/keyword");
        }
    }
}
