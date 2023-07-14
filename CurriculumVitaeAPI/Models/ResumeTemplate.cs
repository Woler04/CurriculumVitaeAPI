namespace CurriculumVitaeAPI.Models
{
    public class ResumeTemplate
    {
        public int? TemplateId { get; set; }
        public int? ResumeId { get; set; }
        public Template? Template { get; set; }
        public Resume? Resume { get; set; }
    }
}