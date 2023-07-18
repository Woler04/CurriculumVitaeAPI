namespace CurriculumVitaeAPI.Models
{
    public class Certificate
    {
        [Key]
        public int CertificateId { get; set; }
        public string CertificateName { get; set; }
        public string IssuingOrganization { get; set; }
        public DateTime IssueDate { get; set; }
        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
        public virtual Resume? Resume { get; set; }
    }
}