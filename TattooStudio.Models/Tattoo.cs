using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        [JsonIgnore]
        [NotMapped]
        public virtual List<ReadyTattoo> ReadyTattoos { get; set; }
        public Tattoo()
        {

            ReadyTattoos = new List<ReadyTattoo>();

        }

        public override string ToString()
        {
            return Sample.ToString();
        }
    }

    [Table("ReadyTattoos")]
    public class ReadyTattoo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RTattooID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Tattoo TattooType { get; set; }
        [ForeignKey(nameof(TattooType))]
        [NotMapped]
        public int TattooID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Work Work { get; set; }
        [ForeignKey(nameof(Work))]
        [NotMapped]
        public int WorkID { get; set; }       
        public int Price { get; set; }
    }
}
