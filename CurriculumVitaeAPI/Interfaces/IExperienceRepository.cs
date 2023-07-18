using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface IExperienceRepository
    {
        ICollection<Experience> GetExperiences();
        Experience GetExperience(int id);
        bool isExperienceExcisting(int id);
        bool CreateExperience(Experience experience);
        bool Save();
    }
}
