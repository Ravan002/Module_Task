using Module_Task.Concrete;
using ModuleTask.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTask.Concrete
{
    public class Product : BaseEntity
    {
        private static int _lastId = 1;
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public Product()
        {
            Id = _lastId++;
        }
        public Product(int categoryId, string productName, double price)
        {
            Id = _lastId++;
            CategoryId = categoryId;
            ProductName = productName;
            Price = price;
        }

        



    }
}
