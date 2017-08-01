using AdventureWorks.Infrastructure.Domain.Entities;
using AdventureWorks.MVC.DTO;
using AutoMapper;

namespace AdventureWorks.MVC.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<PersonDTO, Person>();
        }
    }
}