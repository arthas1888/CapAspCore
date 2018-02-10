using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public String Titulo { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public String Sinopsis { get; set; }
        [StringLength(100)]
        public String Genero { get; set; }


        public Guid AutorId { get; set; }
        [JsonIgnore]
        [ForeignKey("AutorId")]
        public Autor Autor { get; set; }

        [JsonIgnore]
        public List<LibreriaLibro> LibreriaLibros { get; set; }
    }
}
