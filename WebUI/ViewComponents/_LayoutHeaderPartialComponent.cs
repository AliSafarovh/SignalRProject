using Microsoft.AspNetCore.Mvc;
namespace WebUI.ViewComponents
{
    public class _LayoutHeaderPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
