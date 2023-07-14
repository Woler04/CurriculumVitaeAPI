namespace CurriculumVitaeAPI.Models
{
    public class ResumeSkill
    {
        public int? SkillId { get; set; }
        public int? ResumeId { get; set; }
        public Skill? Skill { get; set; }
        public Resume? Resume { get; set; }
    }
}