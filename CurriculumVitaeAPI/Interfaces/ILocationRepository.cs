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
        bool isBindExcsisting(ResumeLocation resumeSkill);
        bool BindLocation(ResumeLocation resumeSkill);
        bool UnbindLocation(ResumeLocation resumeLocation);
        ResumeLocation GetBind(int locationId, int resumeId);
        bool CreateLocation(Location location);
        bool UpdateLocation(Location location);
        bool DeleteLocation(Location location);
        bool Save();

    }
}
