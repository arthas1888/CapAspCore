using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.models;
using WebApplication2.Data;

namespace WebApplication2.Services
{
    public class MyModelManager<T> : CRUD<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public MyModelManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual IEnumerable Read()
        {
            return GetModel.ToList();
        }

        public T Retrieve(int id)
        {
            return GetModel.Find(id);
        }

        public T Retrieve(Guid id)
        {
            return GetModel.Find(id);
        }

        public T Create(T model)
        {
            GetModel.Add(model);
            _context.SaveChanges();
            return model;
        }

        public T Delete(int id)
        {
            var model = GetModel.Find(id);
            if (model == null) return model;
            GetModel.Remove(model);
            _context.SaveChanges();
            return model;
        }

        public T Delete(string id)
        {
            var model = GetModel.Find(id);
            if (model == null) return model;
            GetModel.Remove(model);
            _context.SaveChanges();
            return model;
        }


        public T Update(int id, T model)
        {
            var entity = GetModel.Find(id);
            if (entity == null) return null;
            GetModel.Update(model);
            _context.SaveChanges();
            return model;
        }

        public T Update(string id, T model)
        {
            var entity = GetModel.Find(id);
            if (entity == null) return null;
            GetModel.Update(model);
            _context.SaveChanges();
            return model;
        }

        protected DbSet<T> GetModel
        {
            get { return _context.Set<T>(); }
        }
    }
}
