using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface IResumeRepository
    {
        //get/read
        ICollection<Resume> GetResumes();
        Resume GetResume(int id);
        User GetUserByResume(int id);
        ICollection<Skill> GetSkillsByResumeId(int id);
        ICollection<Location> GetLocationByResumeId(int id);
        ICollection<Language> GetLanguageByResumeId(int id);
        ICollection<Template> GetTemplateByResumeId(int id);
        ICollection<Education> GetEducationByResumeId(int id);
        ICollection<Certificate> GetCertificateByResumeId(int id);
        ICollection<PersonalInfo> GetPersonalInfoByResumeId(int id);
        ICollection<Experience> GetExperienceByResumeId(int id);
        bool isResumeExsisting(int id);

        //post/create
        bool CreateResume(int userId, Resume resume);
        bool Save();
    }
}
