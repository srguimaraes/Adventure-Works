using AdventureWorks.Infrastructure.Domain.Entities;
using AdventureWorks.Infrastructure.Domain.Interfaces.Repositories;

namespace AdventureWorks.Infrastructure.Data.EF.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(AdventureWorks2014Context Db) : base(Db)
        {
        }
    }
}
