using AdventureWorks.Application.Interfaces;
using AdventureWorks.Infrastructure.Domain.Entities;
using AdventureWorks.Infrastructure.Domain.Interfaces.Services;
using AdventureWorks.MVC.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
                IEnumerable<Person> persons = Enumerable.Empty<Person>();

                if (query.ContainsKey("Skip"))
                {
                    persons = _personApp.GetAll().Skip(Convert.ToInt32(query["Skip"].First())));
                }

                if (query.ContainsKey("Take"))
                {
                    persons = persons.Take(Convert.ToInt32(query["Take"].First())));
                }

                if (query.ContainsKey("OrderBy"))
                {
                    var orderby = query["OrderBy"].First();

                    var ascDesc = true;

                    bool.TryParse(query["OrderByAsc"].First(), out ascDesc);

                    persons = ascDesc ? persons.OrderBy(p => p.GetType().GetProperty(orderby).GetValue(p, null)) : persons.OrderByDescending(p => p.GetType().GetProperty(orderby).GetValue(p, null));
                }
                
                IEnumerable<PersonViewModel> personsViewModel = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(persons);

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