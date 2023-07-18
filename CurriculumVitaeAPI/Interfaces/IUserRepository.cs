﻿using CurriculumVitaeAPI.Models;

namespace CurriculumVitaeAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        ICollection<Resume> GetResumesByUser(int id);
        bool isUserExcisting(int id);
        bool CreateUser(User certificate);
        bool Save();
    }
}
