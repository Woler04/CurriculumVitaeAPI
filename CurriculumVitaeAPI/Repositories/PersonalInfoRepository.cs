using CurriculumVitaeAPI.Data;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Repositories
{
    public class PersonalInfoRepository : IPersonalInfoRepository
    {
        private readonly CVDBContext _context;

        public PersonalInfoRepository(CVDBContext context)
        {
            _context = context;
        }

       

        public PersonalInfo GetPersonalInfo(int id)
        {
            return _context.PesronalInfos.Where(pi => pi.PersonalinfoId == id).FirstOrDefault();
        }

        public ICollection<PersonalInfo> GetPersonalInfos()
        {
            return _context.PesronalInfos.ToList();
        }

        public bool isPersonalInfoExcisting(int id)
        {
            return _context.PesronalInfos.Any(pi => pi.PersonalinfoId == id);
        }
        public bool CreatePersonalInfo(PersonalInfo personalInfo)
        {
            _context.Add(personalInfo);
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

        public bool UpdatePersonalInfo(PersonalInfo personalInfo)
        {
            _context.Update(personalInfo);
            return Save();
        }
    }
}
