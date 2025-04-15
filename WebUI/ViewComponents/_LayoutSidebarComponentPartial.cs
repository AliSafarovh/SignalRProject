using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class _LayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
