using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapperAssist;
using IMapperPOC.Service.Models;
using IMapperPOC.Service.ViewModels;

namespace IMapperPOC.Service.Mappers
{
    public interface IPersonToViewMapper : IMapper<Person,PersonViewModel> { }

    public class PersonToViewMapper : Mapper<Person,PersonViewModel>, IPersonToViewMapper
    {
        //You can use dependancy injection here if you want since this class is registered in the container
        //This is mainly used when needing to map child objects.
        public PersonToViewMapper()
        {
            
        }

        public override void DefineMap(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Person, PersonViewModel>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.Birthday.ToShortDateString()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => String.Format("{0} {1}", src.FirstName, src.LastName)))
                
                //alternate way to define the map
                .AfterMap((src,dest) =>
                {
                    var age = Math.Floor((DateTime.Now - src.Birthday).TotalDays/365.25);
                    dest.Age = (int)age;

                    //more maps here
                });
        }
    }
}
