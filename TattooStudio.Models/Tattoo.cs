using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooStudio.Models
{
    public enum Samples { Animal, Person, Abstract, Name }

    [Table("Tattoos")]
    public class Tattoo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TattooID { get; set; }
        public Samples Sample { get; set; }
        
        public int Price { get; set; }

    }
}
