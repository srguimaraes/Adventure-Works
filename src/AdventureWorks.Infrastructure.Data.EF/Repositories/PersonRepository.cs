using AdventureWorks.Infrastructure.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks.Infrastructure.Data.EF.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(AdventureWorks2014Context Db) : base(Db)
        {
        }
    }
}
