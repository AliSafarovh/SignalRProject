﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class _LayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
