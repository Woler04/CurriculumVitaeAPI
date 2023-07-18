namespace CurriculumVitaeAPI.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }

        public virtual ICollection<ResumeSkill?> ResumeSkills { get; set; }
    }
}