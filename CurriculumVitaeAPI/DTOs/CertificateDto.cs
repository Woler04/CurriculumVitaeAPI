namespace CurriculumVitaeAPI.DTOs
{
    public class CertificateDto
    {
        public int CertificateId { get; set; }
        public string CertificateName { get; set; }
        public string IssuingOrganization { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
