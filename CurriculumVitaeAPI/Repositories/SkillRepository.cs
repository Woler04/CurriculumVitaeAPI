using CurriculumVitaeAPI.Data;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private CVDBContext _context;

        public SkillRepository(CVDBContext context )
        {
            this._context = context;
        }

        public ICollection<Resume> GetResumeWithSkill(int skillId)
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
    }
}
