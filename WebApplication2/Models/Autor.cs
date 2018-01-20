using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Autor
    {
        public Guid Id { get; set; }

        [StringLength(100)]
        [Required]
        public String Nombre { get; set; }
        [StringLength(100)]
        public String Apellido { get; set; }

        //[JsonIgnore]
        public List<Libro> Libros { get; set; }

    }
}
