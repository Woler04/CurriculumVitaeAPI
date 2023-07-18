using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface ISkillRepository
    {
        ICollection<Skill> GetSkills();
        Skill GetSkill(int id);
        ICollection<Resume> GetResumesBySkillId(int skillId);
        bool isSkillExsisting(int id);

        bool CreateSkill(int resumeId, Skill skill);

        bool Save();
    }
}
