using System.Collections.Generic;
using AdventureWorks.Infrastructure.Domain.Entities;

namespace AdventureWorks.Infrastructure.Domain.Interfaces.Services
{
    public interface IPersonService : IServiceBase<Person>
    {
        IEnumerable<Person> GetTopPersons(IEnumerable<Person> persons);
    }
}
