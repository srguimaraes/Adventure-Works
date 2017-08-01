using AdventureWorks.Application.Interfaces;
using AdventureWorks.Infrastructure.Domain.Entities;
using AdventureWorks.MVC.Helpers;
using AdventureWorks.MVC.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
            IQueryCollection query = HttpContext.Request.Query;
                        
            try
            {
                IQueryable<Person> persons = _personApp.GetAll();
                
                if (query.ContainsKey("OrderBy"))
                {
                    var orderby = query["OrderBy"].First();

                    var ascDesc = true;

                    if (query["OrderByAsc"].FirstOrDefault() != null)
                    {
                        bool.TryParse(query["OrderByAsc"].First(), out ascDesc);
                    }

                    persons = persons.OrderBy(p=> p.FirstName);
                }

                if (query.ContainsKey("FirstName"))
                {
                    persons = persons.Where(p=> p.FirstName.Contains(query["FirstName"].First()));
                }

                if (query.ContainsKey("Skip"))
                {
                    persons = persons.Skip(Convert.ToInt32(query["Skip"].First()));
                }

                if (query.ContainsKey("Take"))
                {
                    persons = persons.Take(Convert.ToInt32(query["Take"].First()));
                }
                
                IEnumerable<PersonViewModel> personsViewModel = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(persons.ToList());

                return new ObjectResult(personsViewModel);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Int32 id)
        {
            try
            {
                Person person = _personApp.GetById(id);

                PersonViewModel personViewModel = _mapper.Map<Person, PersonViewModel>(person);

                return new ObjectResult(personViewModel);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message);
            }
        }
    }
}