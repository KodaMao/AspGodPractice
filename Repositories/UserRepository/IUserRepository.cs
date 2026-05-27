using AspGodPractice.Models;
using System.Collections.Generic;

namespace AspGodPractice.Repositories.UserRepository
{
     public  interface IUserRepository
    {
        User CreateUser(CreateUserDto user);
        List<User> GetAllUsers();
        User GetUserDetailsById(int id);
    }
}
