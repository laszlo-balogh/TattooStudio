using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Endpoint.Validators;
using TattooStudio.Models;

namespace TattooStudio.Endpoint.DTOs
{
    public class ReadyTattooDto
    {
        public int RTattooID { get; set; }

        public virtual Tattoo TattooType { get; set; }

        public int TattooID { get; set; }

        public virtual Work Work { get; set; }

        public int WorkID { get; set; }

        [Range(1,int.MaxValue)]
        public int Price { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class TattooDto
    {
        public int TattooID { get; set; }

        [IsEnumValidator]
        public Samples Sample { get; set; }

        public bool IsDeleted { get; set; }

    }
}
