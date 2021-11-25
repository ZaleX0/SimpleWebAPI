using Microsoft.AspNetCore.JsonPatch;
using SimpleWebAPI.Models;
using System.Collections.Generic;

namespace SimpleWebAPI.Services
{
    public interface IPersonService
    {
        int Create(CreatePersonDto dto);
        IEnumerable<PersonDto> GetAll();
        PersonDto GetById(int id);
        void Delete(int id);
        void Update(UpdatePersonDto dto, int id);
        void Patch(JsonPatchDocument<UpdatePersonDto> patchEntity, int id);
    }
}