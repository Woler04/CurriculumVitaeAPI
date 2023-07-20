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
            return _context.Resumes.Where(r => r.ResumeId == id).FirstOrDefault();
        }

        public ICollection<Resume> GetResumes()
        {
            return _context.Resumes.OrderBy(r => r.ResumeId).ToList();
                
        }


        public bool isResumeExsisting(int id)
        {
            return _context.Resumes.Any(r => r.ResumeId == id);
        }
        public bool CreateResume(int userId, Resume resume)
        {
            var userEntity = _context.Users.Where(e => e.Id == userId).FirstOrDefault();

            resume.User = userEntity;

            _context.Add(resume);

            return Save();
        }
        public bool Save()
        {
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
                return false;   
        }

        public User GetUserByResume(int id)
        {
            return _context.Users.Where(u => u.Resumes.Contains(GetResume(id))).FirstOrDefault();
        }

        public ICollection<Skill> GetSkillsByResumeId(int resumeId)
        {
            return _context.ResumeSkills.Where(rs => rs.ResumeId == resumeId).Select(s => s.Skill).ToList();
        }

        public ICollection<Location> GetLocationByResumeId(int resumeId)
        {
            return _context.ResumeLocations.Where(e => e.ResumeId == resumeId).Select(s => s.Location).ToList();

        }

        public ICollection<Language> GetLanguageByResumeId(int resumeId)
        {
            return _context.ResumeLanguages.Where(e => e.ResumeId == resumeId).Select(s => s.Language).ToList();
        }

        public Template GetTemplateByResumeId(int resumeId)
        {
            return _context.ResumeTemplates.Where(e => e.ResumeId == resumeId).Select(s => s.Template).FirstOrDefault();
        }

        public ICollection<Education> GetEducationByResumeId(int resumeId)
        {
            return _context.Educations.Where(e => e.ResumeId == resumeId).ToList();
        }

        public ICollection<Certificate> GetCertificateByResumeId(int resumeId)
        {
            return _context.Certificates.Where(e => e.ResumeId == resumeId).ToList();
        }

        public ICollection<PersonalInfo> GetPersonalInfoByResumeId(int resumeId)
        {
            return _context.PesronalInfos.Where(e => e.ResumeId == resumeId).ToList();
        }

        public ICollection<Experience> GetExperienceByResumeId(int resumeId)
        {
            return _context.Experiences.Where(e => e.ResumeId == resumeId).ToList();
        }

        public bool UpdateResume(Resume resume)
        {
            _context.Update(resume);
            return Save();
        }
    }
}
