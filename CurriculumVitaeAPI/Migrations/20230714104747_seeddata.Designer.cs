﻿// <auto-generated />
using System;
using CurriculumVitaeAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CurriculumVitaeAPI.Migrations
{
    [DbContext(typeof(CVDBContext))]
    [Migration("20230714104747_seeddata")]
    partial class seeddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Certificate", b =>
                {
                    b.Property<int>("CertificateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CertificateId"), 1L, 1);

                    b.Property<string>("CertificateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssuingOrganization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.HasKey("CertificateId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Education", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EducationId"), 1L, 1);

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FieldOfStudy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EducationId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExperienceId"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ExperienceId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"), 1L, 1);

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.PersonalInfo", b =>
                {
                    b.Property<int>("PersonalinfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonalinfoId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.HasKey("PersonalinfoId");

                    b.HasIndex("ResumeId");

                    b.ToTable("PesronalInfos");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Resume", b =>
                {
                    b.Property<int>("ResumeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResumeId"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ResumeId");

                    b.HasIndex("UserId");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.ResumeLanguage", b =>
                {
                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("ResumeId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("ResumeLanguages");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.ResumeLocation", b =>
                {
                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("ResumeId", "LocationId");

                    b.HasIndex("LocationId");

                    b.ToTable("ResumeLocations");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.ResumeSkill", b =>
                {
                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("ResumeId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("ResumeSkills");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.ResumeTemplate", b =>
                {
                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("ResumeId", "TemplateId");

                    b.HasIndex("TemplateId");

                    b.ToTable("ResumeTemplates");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"), 1L, 1);

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Template", b =>
                {
                    b.Property<int>("TemplateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateId"), 1L, 1);

                    b.Property<string>("TemplateFilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateId");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Certificate", b =>
                {
                    b.HasOne("CurriculumVitaeAPI.Models.Resume", null)
                        .WithMany("Certificates")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Education", b =>
                {
                    b.HasOne("CurriculumVitaeAPI.Models.Resume", null)
                        .WithMany("Educations")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Experience", b =>
                {
                    b.HasOne("CurriculumVitaeAPI.Models.Resume", null)
                        .WithMany("Experiences")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.PersonalInfo", b =>
                {
                    b.HasOne("CurriculumVitaeAPI.Models.Resume", null)
                        .WithMany("PersonalInfos")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Resume", b =>
                {
                    b.HasOne("CurriculumVitaeAPI.Models.User", "User")
                        .WithMany("Resumes")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.ResumeLanguage", b =>
                {
                    b.HasOne("CurriculumVitaeAPI.Models.Language", "Language")
                        .WithMany("ResumeLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurriculumVitaeAPI.Models.Resume", "Resume")
                        .WithMany("ResumeLanguages")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.ResumeLocation", b =>
                {
                    b.HasOne("CurriculumVitaeAPI.Models.Location", "Location")
                        .WithMany("ResumeLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurriculumVitaeAPI.Models.Resume", "Resume")
                        .WithMany("ResumeLocations")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.ResumeSkill", b =>
                {
                    b.HasOne("CurriculumVitaeAPI.Models.Resume", "Resume")
                        .WithMany("ResumeSkills")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurriculumVitaeAPI.Models.Skill", "Skill")
                        .WithMany("ResumeSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.ResumeTemplate", b =>
                {
                    b.HasOne("CurriculumVitaeAPI.Models.Resume", "Resume")
                        .WithMany("ResumeTemplates")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurriculumVitaeAPI.Models.Template", "Template")
                        .WithMany("ResumeTemplates")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Language", b =>
                {
                    b.Navigation("ResumeLanguages");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Location", b =>
                {
                    b.Navigation("ResumeLocations");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Resume", b =>
                {
                    b.Navigation("Certificates");

                    b.Navigation("Educations");

                    b.Navigation("Experiences");

                    b.Navigation("PersonalInfos");

                    b.Navigation("ResumeLanguages");

                    b.Navigation("ResumeLocations");

                    b.Navigation("ResumeSkills");

                    b.Navigation("ResumeTemplates");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Skill", b =>
                {
                    b.Navigation("ResumeSkills");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.Template", b =>
                {
                    b.Navigation("ResumeTemplates");
                });

            modelBuilder.Entity("CurriculumVitaeAPI.Models.User", b =>
                {
                    b.Navigation("Resumes");
                });
#pragma warning restore 612, 618
        }
    }
}
