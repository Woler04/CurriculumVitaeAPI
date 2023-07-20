using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface ISkillRepository
    {
        ICollection<Skill> GetSkills();
        Skill GetSkill(int id);
        ICollection<Resume> GetResumesBySkillId(int skillId);
        bool isSkillExsisting(int id);
        bool isBindExcsisting(ResumeSkill resumeSkill);
        ResumeSkill GetBind(int skillId, int resumeId);
        bool BindSkill(ResumeSkill resumeSkill);
        bool UnbindSkill(ResumeSkill resumeSkill);
        bool CreateSkill(Skill skill);
        bool UpdateSkill(Skill skill);
        bool DeleteSkill(Skill skill);
        bool Save();
    }
}
