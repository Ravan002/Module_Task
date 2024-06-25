using ModuleTask.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ModuleTask.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private static List<Category> _categories = new List<Category>();


        public CategoryManager()
        {
            _categories.AddRange(new List<Category>()
            {
                new ("Un memulatlari"),
                new ("Ickiler"),
                new("Sekerler"),
                new("Texniki Avadanliqlar")
            });
        }

        public void Add(User user, Category newEntity)
        {
            List<string> haveAccessRoles = new()
            {
                "Admin","Head Cassier"
            };
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                Console.WriteLine($"Successfully added to the list Id: {newEntity.Id} Name: {newEntity.CategoryName}");
            }
        }

        public void Delete(User user, int id)
        {
            List<string> haveAccessRoles = new()
            {
                "Admin","Head Cassier"
            };
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                Category? selectedCategory = GetById(user, id);
                if (selectedCategory != null)
                {
                    _categories.Remove(selectedCategory);
                    Console.WriteLine($"Succesfully deleted {selectedCategory.CategoryName}");
                }
            }
        }

        public List<Category>? GetAll(User user)
        {
            List<string> haveAccessRoles = new()
            {
                "Admin","Head Cassier","Satici"
            };
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                Console.WriteLine($"Number of Category: {_categories.Count}");
                foreach (Category category in _categories)
                {
                    Console.WriteLine($"ID: {category.Id}  Category Name: {category.CategoryName}");
                }
                return _categories;
            }
            return null;
        }

        public Category? GetById(User user, int id)
        {
            List<string> haveAccessRoles = new()
            {
                "Admin","Head Cassier","Satici"
            };
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                foreach (Category category in _categories)
                {
                    if (category.Id == id)
                        return category;
                }
                Console.WriteLine("Category doesn't exist");
                return null;
            }
            return null;
        }

        public void Update(User user, Category? selectedCategory)
        {
            List<string> haveAccessRoles = new()
            {
                "Admin","Head Cassier"
            };
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                if (selectedCategory != null)
                {
                    selectedCategory.CategoryName = "UpdatedCategory";
                }
                else
                {
                    Console.WriteLine("Category doesn't exist");
                }
            }
        }
    }
}
