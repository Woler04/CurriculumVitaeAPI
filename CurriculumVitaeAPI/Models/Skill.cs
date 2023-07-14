namespace CurriculumVitaeAPI.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }

        public ICollection<ResumeSkill?> ResumeSkills { get; set; }
    }
}