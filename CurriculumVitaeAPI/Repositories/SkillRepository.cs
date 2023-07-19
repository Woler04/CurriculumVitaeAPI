using CurriculumVitaeAPI.Data;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly CVDBContext _context;

        public SkillRepository(CVDBContext context )
        {
            this._context = context;
        }

        public ICollection<Resume> GetResumesBySkillId(int skillId)
        {
            return _context.ResumeSkills.Where(rs => rs.SkillId == skillId).Select(r => r.Resume).ToList();
        }

        public Skill GetSkill(int id)
        {
            return _context.Skills.Where(s => s.SkillId == id).FirstOrDefault();
        }

        public ICollection<Skill> GetSkills()
        {
            return _context.Skills.ToList();
        }

        public bool isSkillExsisting(int id)
        {
            return _context.Skills.Any(s => s.SkillId == id);
        }
        public bool CreateSkill(Skill skill)
        {
            _context.Add(skill);

            return Save();
        }

        public bool BindSkill(ResumeSkill resumeSkill)
        {
            _context.Add(resumeSkill);
            return Save();
        }
        public bool isBindExcsisting(ResumeSkill resumeSkill)
        {
            return _context.ResumeSkills.Any(rs => rs.Equals(resumeSkill));
        }
        public bool UpdateSkill(Skill skill)
        {
            _context.Update(skill);
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
