using ModuleTask.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTask.Concrete
{
    public class Category : IEntity
    {
        private static int _lastId = 1;
        public string CategoryName { get; set; }

        public Category()
        {
            Id=_lastId++;
        }
        public Category(string categoryName)
        {
            Id = _lastId++;
            CategoryName = categoryName;
        }
    }
}
