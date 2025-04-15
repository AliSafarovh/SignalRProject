using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class _LayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
