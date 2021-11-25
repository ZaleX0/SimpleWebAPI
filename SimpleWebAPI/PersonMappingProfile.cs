using AutoMapper;
using SimpleWebAPI.Entities;
using SimpleWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<CreatePersonDto, Person>()
                .ForMember(p => p.Address,
                    c => c.MapFrom(dto => new Address()
                    {
                        City = dto.City,
                        Street = dto.Street,
                        PostalCode = dto.PostalCode
                    }));

            CreateMap<Person, UpdatePersonDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));
        }
    }
}
