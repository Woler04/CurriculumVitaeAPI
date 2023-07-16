﻿using AutoMapper;
using CurriculumVitaeAPI.DTOs;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Resume, ResumeDto>();
            CreateMap<Skill, SkillDto>();
            CreateMap<Experience, ExperienceDto>();
            CreateMap<Certificate, CertificateDto>();
            CreateMap<PersonalInfo, PersonalInfoDto>();
            CreateMap<Education, EducationDto>();
        }
    }
}
