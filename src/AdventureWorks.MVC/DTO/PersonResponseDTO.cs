using System.Collections.Generic;

namespace AdventureWorks.MVC.DTO
{
    public class PersonResponseDTO
    {
        public IEnumerable<PersonDTO> Items { get; set; }
        public int TotalItems { get; set; }
    }
}
