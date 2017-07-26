using Microsoft.AspNetCore.Mvc;

public class PersonController : Controller {
    
    [Route("api/person")]
    [HttpGet]
    public string Get() {
        return string.Empty;
    }
}