using CurriculumVitaeAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CurriculumVitaeAPI.Data
{
    public class CVDBContext : DbContext
    {
        public CVDBContext(DbContextOptions<CVDBContext> options) : base(options)
        { }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<PersonalInfo> PesronalInfos { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Template> Templates { get; set; }

        //JOIN TABLES
        public DbSet<ResumeLanguage> ResumeLanguages { get; set; }
        public DbSet<ResumeLocation> ResumeLocations { get; set; }
        public DbSet<ResumeSkill> ResumeSkills { get; set; }
        public DbSet<ResumeTemplate> ResumeTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
