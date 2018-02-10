using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class LibreriaManager : MyModelManager<Libreria>
    {
        private readonly ApplicationDbContext _context;

        public LibreriaManager(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        override
        public IEnumerable Read()
        {
            var entities = _context.Librerias.Include(x => x.LibreriaLibros);
            return entities;
        }

        public IEnumerable ReadNames()
        {
            return GetModel.Select(x => x.Nombre).ToList();
        }

        override
        public Libreria Create(Libreria model)
        {
            var entity = base.Create(model);
            if (model.Libros.Count() > 0)
            {
                var librosToSave = new List<LibreriaLibro>();
                _context.Entry(entity).Collection(x => x.LibreriaLibros).Load();
                foreach (var libroId in model.Libros)
                {
                    librosToSave.Add(new LibreriaLibro()
                    {
                        LibreriaId = entity.Id,
                        LibroId = libroId
                    });
                }
                entity.LibreriaLibros.AddRange(librosToSave);
                _context.SaveChanges();
            }
            return entity;
        }

        override
        public Libreria Update(int id, Libreria model)
        {
            var entity = base.Retrieve(id);
            if (entity == null) return null;
            entity.Nombre = model.Nombre;
            if (model.Libros.Count() > 0)
            {
                var librosToSave = new List<LibreriaLibro>();
                
                _context.Entry(entity).Collection(x => x.LibreriaLibros).Load();
                entity.LibreriaLibros.RemoveAll(x => x.LibreriaId == entity.Id);
                foreach (var libroId in model.Libros)
                {
                    librosToSave.Add(new LibreriaLibro()
                    {
                        LibreriaId = entity.Id,
                        LibroId = libroId
                    });
                }
                entity.LibreriaLibros.AddRange(librosToSave);
                _context.SaveChanges();
            }
            return entity;
        }
    }
}
