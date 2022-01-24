using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Endpoint.Validators;
using TattooStudio.Models;

namespace TattooStudio.Endpoint.DTOs
{
    public class WorkDto
    {
        public int WorkID { get; set; }

        public virtual Customer Customer { get; set; }
        
        public int CustomerID { get; set; }

        public virtual List<ReadyTattoo> Tattoos { get; set; }
                
        [DefaultDateTimeValidator]       
        public DateTime Date { get; set; }

        [Range(1,int.MaxValue)]
        public int TattooCount { get; set; }
        
        public int Price { get { return Tattoos.Sum(x => x.Price); } }
        
        public bool IsDeleted { get; set; }
    }
}
