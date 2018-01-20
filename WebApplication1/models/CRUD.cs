using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.models
{
    interface CRUD<T> where T : class
    {
        T Create(T model);
        List<T> Read();
        T Retrieve(int id);
        T Update(int id, T model);
        T Delete(int id);
    }
}
