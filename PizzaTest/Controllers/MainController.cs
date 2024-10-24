using Microsoft.AspNetCore.Mvc;

namespace PizzaTest.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
