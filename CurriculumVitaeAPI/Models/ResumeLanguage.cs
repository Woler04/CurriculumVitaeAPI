namespace CurriculumVitaeAPI.Models
{
    public class ResumeLanguage
    {
        public int? LanguageId { get; set; }
        public int? ResumeId { get; set; }
        public virtual Language? Language { get; set; }
        public virtual Resume? Resume { get; set; }
    }
}