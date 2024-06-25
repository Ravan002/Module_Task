using ModuleTask.Abstract;

namespace ModuleTask.Concrete
{
    public class UserManager : IUserService
    {
        private static List<User> _users= new List<User>();
        private static List<string> haveAccessRoles = new List<string>()
        {
            "Admin"
        };
        public UserManager(User admin)
        {
            _users.Add(admin);
        }

        public void Add(User user, User newEntity)
        {
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                Console.WriteLine($"Successfully added to the List: Id: {newEntity.Id}  Role: {newEntity.Role} FullName: {newEntity.FullName}");
                _users.Add(newEntity);
            }
        }

        public void Delete(User user, int id)
        {
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                User? selectedUser = GetById(user, id);
                if (selectedUser != null)
                {
                    _users.Remove(selectedUser);
                    Console.WriteLine($"Succesfully deleted {selectedUser.FullName} adli user");
                }
            }
        }

        public List<User>? GetAll(User user)
        {
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                Console.WriteLine($"Number of Users: {_users.Count}");
                foreach (User u in _users)
                {
                    Console.WriteLine($"ID: {u.Id}  Full Name: {u.FullName} Role: {u.Role}");
                }
                return _users;
            }
            return null;
        }

        public User? GetById(User user, int id)
        {
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                foreach (User item in _users)
                {
                    if (item.Id == id)
                        return item;
                }
                Console.WriteLine("User doesn't exist");
                return null;
            }
            return null;
        }

        public void Update(User user, User selectedUser)
        {
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                if (selectedUser != null)
                {
                    selectedUser.FullName = "Updated Ad";
                    selectedUser.Password = "123update";
                    Console.WriteLine("Succesfully updated");
                }
            }
        }
    }
}
