namespace CurriculumVitaeAPI.Models
{
    public class ResumeLocation
    {
        public int? LocationId { get; set; }
        public int? ResumeId { get; set; }
        public virtual Location? Location { get; set; }
        public virtual Resume? Resume { get; set; }
    }
}