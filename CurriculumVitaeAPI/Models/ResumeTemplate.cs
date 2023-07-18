namespace CurriculumVitaeAPI.Models
{
    public class ResumeTemplate
    {
        public int? TemplateId { get; set; }
        public int? ResumeId { get; set; }
        public virtual Template? Template { get; set; }
        public virtual Resume? Resume { get; set; }
    }
}