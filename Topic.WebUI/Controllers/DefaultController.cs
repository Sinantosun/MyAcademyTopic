using Microsoft.AspNetCore.Mvc;

namespace Topic.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
