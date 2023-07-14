using CurriculumVitaeAPI.Data;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Repositories
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly CVDBContext _context;

        public ResumeRepository(CVDBContext context)
        {
            _context = context;
        }

        public ICollection<Resume> GetResumes()
        {
            return _context.Resumes.OrderBy(r => r.ResumeId).ToList();
        }
    }
}
