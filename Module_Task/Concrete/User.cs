using ModuleTask.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTask.Concrete
{
    public class User : IEntity
    {
        private static int _lastId = 1;
        public string FullName { get; set; }
        public string Username   { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User()
        {
            Id = _lastId++;
        }
        public User(string fullName, string username, string password, string role)
        {
            Id= _lastId++;
            FullName = fullName;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
