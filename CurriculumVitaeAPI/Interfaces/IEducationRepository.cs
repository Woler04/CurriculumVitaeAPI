using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface IEducationRepository
    {
        ICollection<Education> GetEducations();
        Education GetEducation(int id);
        bool isEducationExcisting(int id);
        bool CreateEducation(Education education);
        bool updateEducation(Education education);
        bool Save();
    }
}
