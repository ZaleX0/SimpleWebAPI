using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebAPI.Entities;
using SimpleWebAPI.Models;
using SimpleWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }



        [HttpGet]
        public ActionResult<IEnumerable<PersonDto>> GetAll()
        {
            var personDtos = _personService.GetAll();
            return Ok(personDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonDto> GetById([FromRoute] int id)
        {
            var personDto = _personService.GetById(id);
            if (personDto is null)
                return NotFound();
            return Ok(personDto);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreatePersonDto dto)
        {
            int id = _personService.Create(dto);
            return Created($"/person/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
