namespace CurriculumVitaeAPI.Models
{
    public class Resume
    {
        public int ResumeId { get; set; }
        public string Title { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public ICollection<ResumeSkill?> Skills { get; set; }
        public ICollection<ResumeLocation?> Locations { get; set; }
        public ICollection<Certificate?> Certificates { get; set; }
        public ICollection<Education?> Educations { get; set; }
        public ICollection<ResumeLanguage?> Languages { get; set; }
        public ICollection<Template?> Templates { get; set; }
    }
}