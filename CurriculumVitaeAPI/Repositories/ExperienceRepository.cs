using AutoMapper;
using CurriculumVitaeAPI.Data;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private CVDBContext _context;
        private IMapper _mapper;

        public ExperienceRepository(CVDBContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
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
    }
}
