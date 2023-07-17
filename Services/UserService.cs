using CRUD.API.Data;
using CRUD.API.Models;
using System.Reflection.Metadata.Ecma335;

namespace CRUD.API.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if(user != null) 
            { 
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public User GetUserByEmail(string email)
        {
            var user = _context.Users.Where(u => u.email == email).FirstOrDefault();
            return user;
        }

        public User GetUserById(int Id)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == Id);
            return user;
        }

        public User GetUserByUsername(string username)
        {
            var user = _context.Users.Where(u =>u.username == username).FirstOrDefault();
            return user;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool UpdateUser(User User)
        {
            bool status = false;
            try
            {
                var user = _context.Users.Where(u => u.username == User.username).FirstOrDefault();
                if(user != null)
                {
                    user.email = User.email;
                    user.firstname = User.firstname;
                    user.lastname = User.lastname;
                    user.phonenumber = User.phonenumber;
                    user.password = User.password;

                    _context.Users.Update(user);
                    _context.SaveChanges();
                    status = true;
                }
            }
            catch(Exception ex) { }
            return status;
        }
    }
}
