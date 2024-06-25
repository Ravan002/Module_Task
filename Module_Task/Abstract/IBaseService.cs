using ModuleTask.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTask.Abstract
{
    public interface IBaseService<T>
    {
        void Add(User user, T newEntity);
        List<T>? GetAll(User user);
        T? GetById(User user, int id);
        void Update(User user, T entity);
        void Delete(User user, int id);
    }
}
