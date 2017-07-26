using System;
using System.Generic.Collections;
using Microsoft.AspNetCore.Mvc;

public class PersonController : Controller {
    
    [Route("api/person")]
    [HttpGet]
    public IEnumerable<Person> Get() {
        return Enumerable.Empty<Person>();
    }
}