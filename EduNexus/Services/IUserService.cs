using System.Collections.Generic;
using EduNexus.Models;

namespace EduNexus.Services;

public interface IUserService
{
    IEnumerable<User> GetAllUsers();
    User? GetUserById(object id);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(User user);
    User? GetUserByEmail(string email);
    User HandleGoogleLogin(string email, string name, string providerId);
}
