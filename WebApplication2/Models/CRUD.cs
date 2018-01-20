using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.models
{
    public interface CRUD<T> where T : class
    {
        T Create(T model);
        IEnumerable Read();
        T Retrieve(int id);
        T Update(int id, T model);
        T Delete(int id);
        T Retrieve(Guid id);
        T Update(string id, T model);
        T Delete(string id);
    }
}
