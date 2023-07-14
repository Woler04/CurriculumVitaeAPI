namespace CurriculumVitaeAPI.Models
{
    public class ResumeLocation
    {
        public int? LocationId { get; set; }
        public int? ResumeId { get; set; }
        public Location? Location { get; set; }
        public Resume? Resume { get; set; }
    }
}