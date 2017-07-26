using AdventureWorks.Infrastructure.Domain.Entities;
using AdventureWorks.Infrastructure.Domain.Interfaces.Services;
using AdventureWorks.MVC.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AdventureWorks.MVC.Api.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personApp;
        
        public PersonController(IPersonService personApp)
        {
            _personApp = personApp;
        }

        public IEnumerable<PersonViewModel> Get()
        {
            IEnumerable<Person> persons = _personApp.GetAll();

            IEnumerable<PersonViewModel> personsViewModel = Mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(persons);

            return personsViewModel;
        }
    }
}