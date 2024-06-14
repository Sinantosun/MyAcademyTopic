using Microsoft.AspNetCore.Mvc;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    public class LayoutController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
