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

        public virtual ICollection<Certificate?> Certificates { get; set; }
        public virtual ICollection<Education?> Educations { get; set; }
        public virtual ICollection<Experience?> Experiences { get; set; }
        public virtual ICollection<PersonalInfo?> PersonalInfos { get; set; }
        public virtual ICollection<ResumeLocation?> ResumeLocations { get; set; }
        public virtual ICollection<ResumeSkill?> ResumeSkills { get; set; }
        public virtual ICollection<ResumeLanguage?> ResumeLanguages { get; set; }
        public virtual ICollection<ResumeTemplate?> ResumeTemplates { get; set; }
    }
}