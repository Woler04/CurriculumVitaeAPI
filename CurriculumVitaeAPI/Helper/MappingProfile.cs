using AutoMapper;
using CurriculumVitaeAPI.DTOs;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Resume, ResumeDto>();
            CreateMap<ResumeDto, Resume>();
            CreateMap<Skill, SkillDto>();
            CreateMap<SkillDto, Skill>();
            CreateMap<Experience, ExperienceDto>();
            CreateMap<Certificate, CertificateDto>();
            CreateMap<Location, LocationDto>();
            CreateMap<Template, TemplateDto>();
            CreateMap<PersonalInfo, PersonalInfoDto>();
            CreateMap<User, UserDto>();
            CreateMap<Language, LanguageDto>();
            CreateMap<Education, EducationDto>();
        }
    }
}
