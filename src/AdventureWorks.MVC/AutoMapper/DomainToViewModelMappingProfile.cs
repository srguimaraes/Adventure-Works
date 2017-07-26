using AutoMapper;
using AdventureWorks.Infrastructure.Domain.Entities;
using AdventureWorks.MVC.ViewModels;

namespace AdventureWorks.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<PersonViewModel, Person>();
        }
    }
}