using CurriculumVitaeAPI.Data;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly CVDBContext _context;

        public LanguageRepository(CVDBContext context)
        {
            _context = context;
        }


        public Language GetLanguage(int id)
        {
            return _context.Languages.Where(l => l.LanguageId == id).FirstOrDefault();
        }

        public ICollection<Language> GetLanguages()
        {
            return _context.Languages.ToList();
        }

        public ICollection<Resume> GetResumesByLanguage(int id)
        {
            return _context.ResumeLanguages.Where(rl => rl.LanguageId == id).Select(r => r.Resume).ToList();
        }

        public bool isLanguageExcisting(int id)
        {
            return _context.Languages.Any(l => l.LanguageId == id);
        }

        public bool CreateLanguage(Language language)
        {
            _context.Add(language);

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

        public bool isBindExcsisting(ResumeLanguage resumeLanguage)
        {
            return _context.ResumeLanguages.Any(rs => rs.Equals(resumeLanguage));
        }

        public bool Bindlanguage(ResumeLanguage resumeLanguage)
        {
            _context.Add(resumeLanguage);
            return Save();
        }

    }
}
