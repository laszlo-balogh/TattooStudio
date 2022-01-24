using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooStudio.Models.DTOs
{
    public class CustomerDto
    {
        public int CustomerID { get; set; }
        
        public string Name { get; set; }
      
        public string Email { get; set; }
        
        public DateTime BornDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
