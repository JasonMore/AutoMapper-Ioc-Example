using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using IMapperPOC.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMapperPOC.Service.Mappers;

namespace IMapperPOC.Test
{
    [TestClass]
    public class PersonToViewMapperTest
    {
        private IPersonToViewMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            _mapper = new PersonToViewMapper();
        }

        [TestMethod]
        public void CreatePersonViewModel()
        {
            //Arrange
            var dateOfBirth = DateTime.Now.AddDays(-600); // almost 2 years old
            var person = new Person()
                            {
                                Id = 123,
                                Birthday = dateOfBirth, 
                                FirstName = "John",
                                LastName = "Doe"
                            };

            //Act
            var viewmodel = _mapper.CreateInstance(person);

            //Assert
            Assert.AreEqual("John Doe", viewmodel.Name);
            Assert.AreEqual(1, viewmodel.Age);
            Assert.AreEqual(dateOfBirth.ToShortDateString(), viewmodel.DateOfBirth);
        }
    }
}
