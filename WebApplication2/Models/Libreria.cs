using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Libreria
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [NotMapped]
        [Required]
        public int[] Libros { get; set; }

        public List<LibreriaLibro> LibreriaLibros { get; set; }
    }

    public class LibreriaLibro
    {
        public int LibreriaId { get; set; }
        [JsonIgnore]
        public Libreria Libreria { get; set; }

        public int LibroId { get; set; }
        [JsonIgnore]
        public Libro Libro { get; set; }
    }
}
