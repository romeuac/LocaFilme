using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LocaFilme.Models;
using LocaFilme.Dtos;

namespace LocaFilme.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Automapper irah criar uma reflexao entre objetos destes tipos baseados em seus nomes (called a convetion name mapping tool)

            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            // Dto to domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}