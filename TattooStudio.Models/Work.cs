using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooStudio.Models
{
    [Table("Works")]
    public class Work
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkID { get; set; }
        [Required]
        [NotMapped]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }
        public virtual List<Tattoo> Tattoos { get; set; }       
        public DateTime Date { get; set; }
        public int TattooCount { get; set; }
        public int Price { get { return Tattoos.Sum(x => x.Price); } }

        public Work()
        {
           
                Tattoos = new List<Tattoo>();
            
        }

    }
}
