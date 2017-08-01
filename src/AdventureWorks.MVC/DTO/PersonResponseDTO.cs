using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.MVC.DTO
{
    public class PersonResponseDTO
    {
        public IEnumerable<PersonDTO> Items { get; set; }
        public int TotalItems { get; set; }
    }
}
