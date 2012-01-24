using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMapperPOC.Service.Models;
using IMapperPOC.Service.ViewModels;
using IMapperPOC.Service.Mappers;

namespace IMapperPOC.Service.Services
{
    public interface  IPersonService
    {
        PersonViewModel GetTestPerson();
    }

    public class PersonService : IPersonService
    {
        private readonly IPersonToViewMapper _personToViewMapper;

        public PersonService(IPersonToViewMapper personToViewMapper)
        {
            _personToViewMapper = personToViewMapper;
        }

        public PersonViewModel GetTestPerson()
        {
			// Normally this is the point where you would get data from a database or service, 
			// but its just fake data for now
            Person person = new Person()
                                {
                                    Id = 123,
                                    FirstName = "Foo",
                                    LastName = "Bar",
                                    Birthday = DateTime.Parse("1/1/1980")
                                };

            return _personToViewMapper.CreateInstance(person);
        }
    }
}
