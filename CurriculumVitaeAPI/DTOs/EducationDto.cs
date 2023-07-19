﻿namespace CurriculumVitaeAPI.DTOs
{
    public class EducationDto
    {
        public int EducationId { get; set; }
        public string InstitutionName { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
