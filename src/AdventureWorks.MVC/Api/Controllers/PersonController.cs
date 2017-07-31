using AdventureWorks.Application.Interfaces;
using AdventureWorks.Infrastructure.Domain.Entities;
using AdventureWorks.Infrastructure.Domain.Interfaces.Services;
using AdventureWorks.MVC.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AdventureWorks.MVC.Api.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonAppService _personApp;
        private readonly IMapper _mapper;

        public PersonController(IPersonAppService personApp, IMapper mapper)
        {
            _personApp = personApp;
            _mapper = mapper;
        }

        public IActionResult Get()
        {
            try
            {
                IEnumerable<Person> persons = _personApp.GetAll();

                IEnumerable<PersonViewModel> personsViewModel = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(persons);

                return new ObjectResult(personsViewModel);

                //Person person = _personApp.GetById(1);

                //PersonViewModel personViewModel = _mapper.Map<Person, PersonViewModel>(person);

                //return new ObjectResult(personViewModel);
            }
            catch(Exception ex)
            {
                return new ObjectResult(ex);
            }
        }
    }
}