using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface IResumeRepository
    {
        ICollection<Resume> GetResumes();
    }
}
