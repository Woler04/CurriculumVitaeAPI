using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.DTOs
{
    public class ResumeDto
    {
        public int ResumeId { get; set; }
        public string Title { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public User User { get; set; }
        public ICollection<Certificate?> Certificates { get; set; }
        public ICollection<Education?> Educations { get; set; }
        public ICollection<Experience?> Experiences { get; set; }
        public ICollection<PersonalInfo?> PersonalInfos { get; set; }
    }
}
