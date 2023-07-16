using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface IResumeRepository
    {
        ICollection<Resume> GetResumes();
        Resume GetResume(int id);
        User GetUserByResume(int id);
        bool isResumeExsisting(int id);
    }
}
