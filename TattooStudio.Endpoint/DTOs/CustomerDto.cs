using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Endpoint.Validators;

namespace TattooStudio.Endpoint.DTOs
{
    
    public class CustomerDto
    {        
        public int CustomerID { get; set; }        
        
        [MinLength(1)]
        public string Name { get; set; }

        [CustomEmailValidator]
        public string Email { get; set; }

        [DefaultDateTimeValidator]
        public DateTime BornDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
