using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapperAssist;
using IMapperPOC.Service.Models;
using IMapperPOC.Service.ViewModels;
using System.Text.RegularExpressions;

namespace IMapperPOC.Service.Mappers
{
    public interface IPersonToModelMapper : IMapper<PersonViewModel, Person> { }

    public class PersonToModelMapper : Mapper<PersonViewModel, Person>, IPersonToModelMapper
    {
        //You can use dependancy injection here if you want since this class is registered in the container
        public PersonToModelMapper()
        {
            
        }


        public override void DefineMap(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<PersonViewModel, Person>()
                .ForMember(dest => dest.Birthday,opt => opt.MapFrom(src => DateTime.Parse(src.DateOfBirth)))
                
				//Complex mappings usually go here
				.AfterMap((src, dest) =>
                {
                    var name = Regex.Split(src.Name, " ");
                    switch (name.Count())
                    {
                        case 1:
                            dest.FirstName = name[0];
                            break;
                        case 2:
                            dest.FirstName = name[0];
                            dest.LastName = name[1];
                            break;
                    }
                })
                ;
        }
    }
}
