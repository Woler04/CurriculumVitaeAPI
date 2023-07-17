using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface ITemplateRepository
    {
        ICollection<Template> GetTemplates();
        Template GetTemplate(int id);
        ICollection<Resume> GetResumesByTemplate(int id);
        bool isTemplateExcisting(int id);

    }
}
