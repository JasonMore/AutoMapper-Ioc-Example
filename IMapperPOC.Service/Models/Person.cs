using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMapperPOC.Service.Models
{
    public class Person
    {
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
