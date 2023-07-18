using CurriculumVitaeAPI.Data;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Repositories
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly CVDBContext _context;

        public CertificateRepository(CVDBContext context)
        {
            _context = context;
        }

        public Certificate GetCertificate(int id)
        {
            return _context.Certificates.Where(c => c.CertificateId == id).FirstOrDefault();
        }

        public ICollection<Certificate> GetCertificates()
        {
            return _context.Certificates.ToList();
        }

        public ICollection<Resume> GetResumesByCertificateKeyword(string keyword)
        {
            //It should returns all resumes that have the keyword in their name
            return _context.Resumes.Where(r => r.Certificates
            .Any(c => c.CertificateName.ToLower().Contains(keyword.ToLower()))).ToList();
        }

        public bool isCertificateExcisting(int id)
        {
            return _context.Certificates.Any(c => c.CertificateId == id);
        }
        public bool CreateCertificate(Certificate certificate)
        {
            _context.Add(certificate);
            return Save();
        }

        public bool Save()
        {
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
