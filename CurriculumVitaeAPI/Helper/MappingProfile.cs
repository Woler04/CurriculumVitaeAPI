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
            CreateMap<ExperienceDto, Experience>();
            CreateMap<Certificate, CertificateDto>();
            CreateMap<CertificateDto, Certificate>();
            CreateMap<Location, LocationDto>();
            CreateMap<LocationDto, Location>();
            CreateMap<Template, TemplateDto>();
            CreateMap<TemplateDto, Template>();
            CreateMap<PersonalInfo, PersonalInfoDto>();
            CreateMap<PersonalInfoDto, PersonalInfo>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Language, LanguageDto>();
            CreateMap<LanguageDto, Language>();
            CreateMap<Education, EducationDto>();
            CreateMap<EducationDto, Education>();
        }
    }
}
