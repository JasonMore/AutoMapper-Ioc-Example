using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using IMapperPOC.Service.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMapperPOC.Service.ViewModels;

namespace IMapperPOC.Test
{
    [TestClass]
    public class PersonToModelMapperTest
    {
        private PersonToModelMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            _mapper = new PersonToModelMapper();
        }

        [TestMethod]
        public void CreatePersonModel()
        {
            //Arrange
            var birthDate = "1/1/1990";
            var personViewModel = new PersonViewModel()
                                      {
                                          Name = "Foo Bar",
                                          DateOfBirth = birthDate
                                      };


            //Act
            var person = _mapper.CreateInstance(personViewModel);


            //Assert
            Assert.AreEqual("Foo", person.FirstName);
            Assert.AreEqual("Bar", person.LastName);
            Assert.AreEqual(birthDate, person.Birthday.ToShortDateString());

        }
    }
}
