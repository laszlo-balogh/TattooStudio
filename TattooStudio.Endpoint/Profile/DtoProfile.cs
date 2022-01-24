using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TattooStudio.Models;
using TattooStudio.Endpoint;
using TattooStudio.Endpoint.DTOs;

namespace TattooStudio.Endpoint.Profile
{
    public class DtoProfile : AutoMapper.Profile 
    {
        public DtoProfile()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<TattooDto, Tattoo>();
            CreateMap<Tattoo, TattooDto>();

            CreateMap<ReadyTattooDto, ReadyTattoo>();
            CreateMap<ReadyTattoo, ReadyTattooDto>();
            
            CreateMap<WorkDto, Work>();
            CreateMap<Work, WorkDto>();

        }
    }
}
