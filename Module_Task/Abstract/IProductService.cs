using ModuleTask.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTask.Abstract
{
    internal interface IProductService : IBaseService<Product>
    {
        List<Product>? GetByCategoryId(User user, int categoryId);
    }
}
