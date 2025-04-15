using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class _LayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
