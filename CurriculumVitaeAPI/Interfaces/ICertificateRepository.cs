using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface ICertificateRepository
    {
        ICollection<Certificate> GetCertificates();
        Certificate GetCertificate(int id);
        ICollection<Resume> GetResumesByCertificateKeyword(string keyword);
        bool isCertificateExcisting(int id);
        bool CreateCertificate(Certificate certificate);
        bool Save();
    }
}
