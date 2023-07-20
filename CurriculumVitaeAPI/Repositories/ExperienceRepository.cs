using AutoMapper;
using CurriculumVitaeAPI.Data;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly CVDBContext _context;

        public ExperienceRepository(CVDBContext context)
        {
            this._context = context;
        }


        public Experience GetExperience(int id)
        {
            return _context.Experiences.Where(e => e.ExperienceId == id).FirstOrDefault();
        }

        public ICollection<Experience> GetExperiences()
        {
            return _context.Experiences.ToList();
        }

        public bool isExperienceExcisting(int id)
        {
            return _context.Experiences.Any(e => e.ExperienceId == id);
        }

        public bool CreateExperience(Experience experience)
        {
            _context.Add(experience);
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

        public bool UpdateExperience(Experience experience)
        {
            _context.Update(experience);
            return Save();
        }
    }
}
