namespace CurriculumVitaeAPI.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
        public virtual Resume? Resume { get; set; }

    }
}
