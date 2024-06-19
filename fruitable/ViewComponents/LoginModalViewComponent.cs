using Fruitable.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fruitable.ViewComponents
{
    public class LoginModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new LoginViewModel();
            return View(model);
        }
    }
}
