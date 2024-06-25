using ModuleTask.Abstract;

namespace ModuleTask.Concrete
{
    public class ProductManager : IProductService
    {
        private static List<Product> _products= new List<Product>();
        public void Add(User user, Product product)
        {
            List<string> haveAccessRoles = new()
            {
                "Admin","Head Cassier"
            };
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                Console.WriteLine($"Successfully added to the list Id: {product.Id} Name: {product.ProductName} Price: {product.Price}");
                _products.Add(product);
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
                Product? selectedProduct = GetById(user, id);
                if (selectedProduct != null)
                {
                    _products.Remove(selectedProduct);
                    Console.WriteLine($"Succesfully deleted {selectedProduct.ProductName}");
                }
            }
        }
        public List<Product>? GetAll(User user)
        {
            List<string> haveAccessRoles = new()
            {
                "Admin","Head Cassier","Satici"
            };
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                Console.WriteLine($"Number of Product: {_products.Count}");
                foreach (Product product in _products)
                {
                    Console.WriteLine($"ID: {product.Id}  Product Name: {product.ProductName} Price: {product.Price}");
                }
                return _products;
            }
            return null;
        }
        public List<Product>? GetByCategoryId(User user, int categoryId)
        {
            List<Product> productsByCategory = new();
            List<string> haveAccessRoles = new()
            {
                "Admin","Head Cassier","Satici"
            };
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                foreach (Product product in _products)
                {
                    if(product.CategoryId == categoryId)
                    {
                        productsByCategory.Add(product);
                        Console.WriteLine($"ID: {product.Id}  Product Name: {product.ProductName} CategoryId: {product.CategoryId}");
                    }
                }
                return productsByCategory;
            }
            return null;
        }
        public Product? GetById(User user, int id)
        {
            List<string> haveAccessRoles = new()
            {
                "Admin","Head Cassier","Satici"
            };
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                foreach (Product item in _products)
                {
                    if (item.Id == id)
                        return item;
                }
                Console.WriteLine("Product doesn't exist");
                return null;
            }
            return null;
        }
        public void Update(User user, Product? selectedProduct)
        {
            List<string> haveAccessRoles = new()
            {
                "Admin","Head Cassier"
            };
            if (CheckAccessHelper.CheckPermission(user, haveAccessRoles))
            {
                if (selectedProduct != null)
                {
                    selectedProduct.ProductName = "UpdatedProduct";
                    selectedProduct.Price = 567.56;
                    selectedProduct.CategoryId = 2;
                }
            }
            
        }
    }
}
