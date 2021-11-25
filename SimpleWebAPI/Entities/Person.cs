using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
