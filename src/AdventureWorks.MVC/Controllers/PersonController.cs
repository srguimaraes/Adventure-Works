using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.MVC.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}