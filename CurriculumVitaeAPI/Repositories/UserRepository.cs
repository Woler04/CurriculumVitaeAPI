using CurriculumVitaeAPI.Data;
using CurriculumVitaeAPI.Interfaces;
using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CVDBContext _context;

        public UserRepository(CVDBContext context)
        {
            _context = context;
        }

        public ICollection<Resume> GetResumesByUser(int id)
        {
            return _context.Resumes.Where(r => r.UserId == id).ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool isUserExcisting(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
        public bool CreateUser(User user)
        {
            _context.Add(user);
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

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }
    }
}
