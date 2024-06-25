using Microsoft.AspNetCore.Mvc;

namespace Topic.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
