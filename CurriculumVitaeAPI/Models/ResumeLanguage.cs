namespace CurriculumVitaeAPI.Models
{
    public class ResumeLanguage
    {
        public int? LanguageId { get; set; }
        public int? ResumeId { get; set; }
        public Language? Language { get; set; }
        public Resume? Resume { get; set; }
    }
}