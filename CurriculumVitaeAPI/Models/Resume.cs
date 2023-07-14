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

        public ICollection<Certificate?> Certificates { get; set; }
        public ICollection<Education?> Educations { get; set; }
        public ICollection<Experience?> Experiences { get; set; }
        public ICollection<PersonalInfo?> PersonalInfos { get; set; }
        public ICollection<ResumeLocation?> ResumeLocations { get; set; }
        public ICollection<ResumeSkill?> ResumeSkills { get; set; }
        public ICollection<ResumeLanguage?> ResumeLanguages { get; set; }
        public ICollection<ResumeTemplate?> ResumeTemplates { get; set; }
    }
}