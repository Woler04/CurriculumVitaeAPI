using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface IEducationRepository
    {
        ICollection<Education> GetEducations();
        Education GetEducation(int id);
        bool isEducationExcisting(int id);
        bool CreateEducation(Education education);
        bool UpdateEducation(Education education);
        bool DeleteEducation(Education education);
        bool Save();
    }
}
