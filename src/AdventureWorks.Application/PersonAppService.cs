using System.Collections.Generic;
using AdventureWorks.Application.Interface;
using AdventureWorks.Infrastructure.Domain.Entities;
using AdventureWorks.Infrastructure.Domain.Interfaces.Services;

namespace AdventureWorks.Application
{
    public class PersonAppService : AppServiceBase<Person>, IPersonAppService
    {
        private readonly IPersonService _personService;

        public PersonAppService(IPersonService personService)
            : base(personService)
        {
            _personService = personService;
        }

        public IEnumerable<Person> GetTopPersons()
        {
            return _personService.GetTopPersons(_personService.GetAll());
        }
    }
}
