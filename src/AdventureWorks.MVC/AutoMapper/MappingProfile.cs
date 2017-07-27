using AutoMapper;
using AdventureWorks.MVC.ViewModels;
using AdventureWorks.Infrastructure.Domain.Entities;

namespace AdventureWorks.MVC.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonViewModel>();
            CreateMap<PersonViewModel, Person>();
        }
    }
}