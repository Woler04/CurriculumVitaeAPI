namespace CurriculumVitaeAPI.Models
{
    public class PersonalInfo
    {
        [Key]
        public int PersonalinfoId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
    }
}
