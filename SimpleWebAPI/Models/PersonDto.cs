using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.Models
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
