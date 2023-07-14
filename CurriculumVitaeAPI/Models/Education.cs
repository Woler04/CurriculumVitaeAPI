namespace CurriculumVitaeAPI.Models
{
    public class Education
    {
        [Key]
        public int EducationId { get; set; }
        public string InstitutionName { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
    }
}