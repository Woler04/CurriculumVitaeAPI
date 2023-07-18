﻿using CurriculumVitaeAPI.Data;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly CVDBContext _context;
        public LocationRepository(CVDBContext context)
        {
            _context = context;
        }

        public Location GetLocation(int id)
        {
            return _context.Locations.Where(l => l.LocationId == id).FirstOrDefault();
        }

        public ICollection<Location> GetLocations()
        {
            return _context.Locations.ToList();
        }

        public ICollection<Resume> GetResumesByKeyword(string keyword)
        {
            return _context.ResumeLocations
                .Where(rl => rl.Location.City.ToLower().Contains(keyword.ToLower()) ||
                       rl.Location.Country.ToLower().Contains(keyword.ToLower()) ||
                       rl.Location.State.ToLower().Contains(keyword.ToLower()))
                .Select(r => r.Resume).ToList();
        }

        public ICollection<Resume> GetResumesByLocation(int id)
        {
            return _context.ResumeLocations.Where(rl => rl.LocationId == id).Select(r => r.Resume).ToList();
        }

        public bool isLocationExcisting(int id)
        {
            return  _context.Locations.Any(l => l.LocationId == id);
        }

        public bool CreateLocation(int resumeId, Location location)
        {
            var resumeEntity = _context.Resumes.Where(e => e.ResumeId == resumeId).FirstOrDefault();

            var resumeLocation = new ResumeLocation()
            {
                Location = location,
                Resume = resumeEntity
            };
            _context.Add(resumeLocation);

            _context.Add(location);

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
