using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface ITemplateRepository
    {
        ICollection<Template> GetTemplates();
        Template GetTemplate(int id);
        ICollection<Resume> GetResumesByTemplate(int id);
        bool isTemplateExcisting(int id);
        bool isBindExcsisting(ResumeTemplate resumeTemplate);
        bool BindTemplate(ResumeTemplate resumeTemplate);
        bool CreateTemplate(Template template);
        bool UpdateTemplate(Template template);
        bool Save();

    }
}
