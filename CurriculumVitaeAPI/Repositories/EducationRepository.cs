using CurriculumVitaeAPI.Data;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly CVDBContext _context;

        public EducationRepository(CVDBContext context)
        {
            _context = context;
        }


        public Education GetEducation(int id)
        {
            return _context.Educations.Where(e => e.EducationId == id).FirstOrDefault();
        }

        public ICollection<Education> GetEducations()
        {
            return _context.Educations.ToList();
        }

        public bool isEducationExcisting(int id)
        {
            return _context.Educations.Any(e => e.EducationId == id);
        }

        public bool CreateEducation(Education education)
        {
            _context.Add(education);
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
    }
}
