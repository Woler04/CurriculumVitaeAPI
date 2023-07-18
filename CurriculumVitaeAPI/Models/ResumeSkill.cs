namespace CurriculumVitaeAPI.Models
{
    public class ResumeSkill
    {
        public int? SkillId { get; set; }
        public int? ResumeId { get; set; }
        public virtual Skill? Skill { get; set; }
        public virtual Resume? Resume { get; set; }
    }
}