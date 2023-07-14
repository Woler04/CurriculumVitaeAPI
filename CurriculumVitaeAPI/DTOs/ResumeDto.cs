using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.DTOs
{
    public class ResumeDto
    {
        public int ResumeId { get; set; }
        public string Title { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public virtual User? User { get; set; }
    }
}
