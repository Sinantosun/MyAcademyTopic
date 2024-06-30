using Microsoft.AspNetCore.Mvc;

namespace Topic.WebUI.Controllers
{
    public class Testcontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
