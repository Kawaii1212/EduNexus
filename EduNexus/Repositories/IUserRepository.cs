using System.Collections.Generic;
using EduNexus.Models;

namespace EduNexus.Repositories;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    User? GetUserById(object id);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(User user);
    User? GetUserByEmail(string email);
}
