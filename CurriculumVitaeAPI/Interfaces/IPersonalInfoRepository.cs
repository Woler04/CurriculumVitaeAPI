using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface IPersonalInfoRepository
    {
        ICollection<PersonalInfo> GetPersonalInfos();
        PersonalInfo GetPersonalInfo(int id);
        bool isPersonalInfoExcisting(int id);
        bool CreatePersonalInfo(PersonalInfo personalInfo);
        bool UpdatePersonalInfo(PersonalInfo personalInfo);
        bool DeletePersonalInfo(PersonalInfo personalInfo);
        bool Save();
    }
}
