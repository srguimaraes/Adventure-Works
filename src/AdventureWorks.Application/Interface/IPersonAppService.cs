using System.Collections.Generic;
using AdventureWorks.Infrastructure.Domain.Entities;

namespace AdventureWorks.Application.Interface
{
    public interface IPersonAppService : IAppServiceBase<Person>
    {
        IEnumerable<Person> GetTopPersons();
    }
}
