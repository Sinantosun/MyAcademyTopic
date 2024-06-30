using Microsoft.AspNetCore.Mvc;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultSearchComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
