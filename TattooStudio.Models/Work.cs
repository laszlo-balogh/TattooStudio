using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }
        [JsonIgnore]
        public virtual List<ReadyTattoo> Tattoos { get; set; }

        public DateTime Date { get; set; }
        public int TattooCount { get; set; }
        public int Price { get { return Tattoos.Sum(x => x.Price); } }

        #region AUDIT

        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        #endregion

        public Work()
        {

            Tattoos = new List<ReadyTattoo>();

        }
    }
}
