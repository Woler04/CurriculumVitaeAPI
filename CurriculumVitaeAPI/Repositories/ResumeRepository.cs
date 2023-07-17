using CurriculumVitaeAPI.Data;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVitaeAPI.Repositories
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly CVDBContext _context;

        public ResumeRepository(CVDBContext context)
        {
            _context = context;
        }
        public Resume GetResume(int id)
        {
            return _context.Resumes.Where(r => r.ResumeId == id)
                .Include(r => r.PersonalInfos)
                .Include(r => r.Experiences)
                .Include(r => r.Educations)
                .Include(r => r.Certificates)
                .FirstOrDefault();
        }

        public ICollection<Resume> GetResumes()
        {
            return _context.Resumes.OrderBy(r => r.ResumeId).ToList();
                
        }

        public ICollection<Skill> GetSkillsByResumeId(int resumeId)
        {
            return _context.ResumeSkills.Where(rs => rs.ResumeId == resumeId).Select(s => s.Skill).ToList();
        }

        public User GetUserByResume(int id)
        {
            return _context.Users.Where(u => u.Resumes.Contains(GetResume(id))).FirstOrDefault();
        }

        public bool isResumeExsisting(int id)
        {
            return _context.Resumes.Any(r => r.ResumeId == id);
        }
    }
}
