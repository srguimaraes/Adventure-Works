using Microsoft.AspNetCore.Mvc;
using AdventureWorks.Application.Interfaces;

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