using AutoMapper;
using CarDealer.Models.Entities;
using CarDealer.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.MappingProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CarVM, Car>().ReverseMap();
            CreateMap<ClientVM, Client>().ReverseMap();
        }
    }
}
