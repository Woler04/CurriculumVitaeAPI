namespace CurriculumVitaeAPI.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Level { get; set; }

        public virtual ICollection<ResumeLanguage?> ResumeLanguages { get; set; }

    }
}
