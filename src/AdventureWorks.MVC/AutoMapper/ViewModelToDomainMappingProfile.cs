using AutoMapper;
using AdventureWorks.Infrastructure.Domain.Entities;
using AdventureWorks.MVC.ViewModels;

namespace AdventureWorks.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PersonViewModel, Person>();
        }
    }
}