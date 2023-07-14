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
            //Resume Language
            modelBuilder.Entity<ResumeLanguage>()
                .HasKey(e => new { e.ResumeId, e.LanguageId });

            modelBuilder.Entity<ResumeLanguage>()
                .HasOne(e => e.Language)
                .WithMany(e => e.ResumeLanguages)
                .HasForeignKey(e => e.LanguageId);

            modelBuilder.Entity<ResumeLanguage>()
               .HasOne(e => e.Resume)
               .WithMany(e => e.ResumeLanguages)
               .HasForeignKey(e => e.ResumeId);

            //Resume Location
            modelBuilder.Entity<ResumeLocation>()
                .HasKey(e => new { e.ResumeId, e.LocationId });

            modelBuilder.Entity<ResumeLocation>()
                .HasOne(e => e.Location)
                .WithMany(e => e.ResumeLocations)
                .HasForeignKey(e => e.LocationId);

            modelBuilder.Entity<ResumeLocation>()
               .HasOne(e => e.Resume)
               .WithMany(e => e.ResumeLocations)
               .HasForeignKey(e => e.ResumeId);

            //Resume Skill
            modelBuilder.Entity<ResumeSkill>()
               .HasKey(e => new { e.ResumeId, e.SkillId });

            modelBuilder.Entity<ResumeSkill>()
                .HasOne(e => e.Skill)
                .WithMany(e => e.ResumeSkills)
                .HasForeignKey(e => e.SkillId);

            modelBuilder.Entity<ResumeSkill>()
               .HasOne(e => e.Resume)
               .WithMany(e => e.ResumeSkills)
               .HasForeignKey(e => e.ResumeId);

            //Resume Template
            modelBuilder.Entity<ResumeTemplate>()
               .HasKey(e => new { e.ResumeId, e.TemplateId });

            modelBuilder.Entity<ResumeTemplate>()
                .HasOne(e => e.Template)
                .WithMany(e => e.ResumeTemplates)
                .HasForeignKey(e => e.TemplateId);

            modelBuilder.Entity<ResumeTemplate>()
               .HasOne(e => e.Resume)
               .WithMany(e => e.ResumeTemplates)
               .HasForeignKey(e => e.ResumeId);
        }

    }
}
