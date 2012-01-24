using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IMapperPOC.Service.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public int Age { get; set; }
    }
}
