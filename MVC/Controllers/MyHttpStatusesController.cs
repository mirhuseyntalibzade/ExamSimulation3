using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class MyHttpStatusesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
