using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface ILocationRepository
    {
        ICollection<Location> GetLocations();
        Location GetLocation(int id);
        ICollection<Resume> GetResumesByLocation(int id);
        ICollection<Resume> GetResumesByKeyword(string keyword);
        bool isLocationExcisting(int id);
    }
}
