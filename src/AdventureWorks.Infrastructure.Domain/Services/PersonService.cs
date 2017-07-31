using System.Collections.Generic;
using System.Linq;
using AdventureWorks.Infrastructure.Domain.Entities;
using AdventureWorks.Infrastructure.Domain.Interfaces.Repositories;
using AdventureWorks.Infrastructure.Domain.Interfaces.Services;

namespace AdventureWorks.Infrastructure.Domain.Services
{
    public class PersonService : ServiceBase<Person>, IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
            : base(personRepository)
        {
            _personRepository = personRepository;
        }

        public IEnumerable<Person> GetTopPersons()
        {
            return _personRepository.GetAll().Where(p => p.BusinessEntityId < 5);
        }
    }
}
