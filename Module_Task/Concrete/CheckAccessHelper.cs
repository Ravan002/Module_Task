

namespace ModuleTask.Concrete
{
    public static class CheckAccessHelper
    {
        public static bool CheckPermission(User currentUser, List<string> roles)
        {
            foreach (var item in roles)
            {
                if(currentUser.Role == item)
                    return true;
            }
            Console.WriteLine($"{currentUser.Role} doesn't have access to this operation");
            return false;
        }
    }
}
