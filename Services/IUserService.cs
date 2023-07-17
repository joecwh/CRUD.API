using CRUD.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Services
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User GetUserById(int Id);
        public User GetUserByUsername(string username);
        public User GetUserByEmail(string email);
        public bool AddUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int id);
    }
}
