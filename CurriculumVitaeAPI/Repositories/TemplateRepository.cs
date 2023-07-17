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
    }
}
