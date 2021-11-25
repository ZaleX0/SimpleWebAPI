using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using SimpleWebAPI.Entities;
using SimpleWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly PersonDbContext _dbContext;
        private readonly IMapper _mapper;

        public PersonService(PersonDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<PersonDto> GetAll()
        {
            var persons = _dbContext.Persons
                .Include(p => p.Address)
                .ToList();

            var personDtos = _mapper.Map<List<PersonDto>>(persons);

            return personDtos;
        }
        public PersonDto GetById(int id)
        {
            var person = _dbContext.Persons
                .Include(p => p.Address)
                .FirstOrDefault(p => p.Id == id);

            if (person is null) return null;

            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }
        public int Create(CreatePersonDto dto)
        {
            var person = _mapper.Map<Person>(dto);
            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();

            return person.Id;
        }
        public void Delete(int id)
        {
            var person = _dbContext.Persons
                .Include(p => p.Address)
                .FirstOrDefault(p => p.Id == id);

            if (person is null) return;

            _dbContext.Persons.Remove(person);
            _dbContext.Addresses.Remove(person.Address);
            _dbContext.SaveChanges();
        }
        public void Update(UpdatePersonDto dto, int id)
        {
            var person = _dbContext.Persons
                .Include(p => p.Address)
                .FirstOrDefault(p => p.Id == id);

            if (person is null) return;

            person.Name = dto.Name;
            person.Lastname = dto.Lastname;
            person.Address.City = dto.City;
            person.Address.Street = dto.Street;
            person.Address.PostalCode = dto.PostalCode;

            _dbContext.SaveChanges();
        }
        public void Patch(JsonPatchDocument<UpdatePersonDto> patchEntity, int id)
        {
            var person = _dbContext.Persons
                .Include(p => p.Address)
                .FirstOrDefault(p => p.Id == id);

            if (person is null) return;

            var updateDto = _mapper.Map<UpdatePersonDto>(person);
            patchEntity.ApplyTo(updateDto);

            person.Name = updateDto.Name;
            person.Lastname = updateDto.Lastname;
            person.Address.City = updateDto.City;
            person.Address.Street = updateDto.Street;
            person.Address.PostalCode = updateDto.PostalCode;

            _dbContext.SaveChanges();
        }
    }
}
