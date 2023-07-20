using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.DTOs
{
    public class ResumeDto
    {
        public int ResumeId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
    }
}
