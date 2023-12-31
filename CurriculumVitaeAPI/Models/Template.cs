﻿namespace CurriculumVitaeAPI.Models
{
    public class Template
    {
        [Key]
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string TemplateFilePath { get; set; }

        public virtual ICollection<ResumeTemplate?> ResumeTemplates { get; set; }
    }
}