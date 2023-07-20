using CurriculumVitaeAPI.Data;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly CVDBContext _context;

        public TemplateRepository(CVDBContext context)
        {
            _context = context;
        }

        public ICollection<Resume> GetResumesByTemplate(int id)
        {
            return _context.ResumeTemplates.Where(rt => rt.TemplateId == id).Select(r => r.Resume).ToList();
        }

        public Template GetTemplate(int id)
        {
            return _context.Templates.Where(t => t.TemplateId == id).FirstOrDefault();
        }

        public ICollection<Template> GetTemplates()
        {
            return _context.Templates.ToList();
        }

        public bool isTemplateExcisting(int id)
        {
            return _context.Templates.Any(t => t.TemplateId == id);
        }
        public bool CreateTemplate(Template template)
        {
            _context.Add(template);

            return Save();
        }
        public bool BindTemplate(ResumeTemplate resumeTemplate)
        {
            _context.Add(resumeTemplate);
            return Save();
        }
        public bool isBindExcsisting(ResumeTemplate resumeTemplate)
        {
            return _context.ResumeTemplates.Any(rs => rs.Equals(resumeTemplate));
        }

        public bool Save()
        {
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateTemplate(Template template)
        {
            _context.Update(template);
            return Save();
        }

        public bool UnbindTemplate(ResumeTemplate resumeTemplate)
        {
            _context.Remove(resumeTemplate);
            return Save();
        }

        public ResumeTemplate GetBind(int templateId, int resumeId)
        {
            return _context.ResumeTemplates.Where(e => e.TemplateId == templateId && e.ResumeId == resumeId).FirstOrDefault();
        }

        public bool DeleteTemplate(Template template)
        {
            _context.Remove(template);
            return Save();
        }
    }
}
