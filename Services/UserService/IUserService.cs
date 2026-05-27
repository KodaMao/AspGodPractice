using AspGodPractice.Models;
using System.Collections.Generic;

namespace AspGodPractice.Services.UserService
{
    public interface IUserService
    {
        User CreateUser(CreateUserDto user);
        List<User> GetAllUsers();
        User GetUserDetailsById(int id);
    }
}
