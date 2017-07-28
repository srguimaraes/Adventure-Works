using System.Collections.Generic;
using AdventureWorks.Infrastructure.Domain.Entities;

namespace AdventureWorks.Application.Interfaces
{
    public interface IPersonAppService : IAppServiceBase<Person>
    {
        IEnumerable<Person> GetTopPersons();
    }
}
