using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface ILanguageRepository
    {
        ICollection<Language> GetLanguages();
        Language GetLanguage(int id);
        ICollection<Resume> GetResumesByLanguage(int id);
        bool isLanguageExcisting(int id);
    }
}
