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
    public class AutorManager : MyModelManager<Autor>
    {
        public AutorManager(ApplicationDbContext context) : base(context)
        {
        }

        override
        public IEnumerable Read()
        {
            return GetModel
                .Include(x => x.Libros)
                .ToList();
        }

        public IEnumerable ReadNames()
        {
            return GetModel.Select(x => x.Nombre).ToList();
        }
    }
}
