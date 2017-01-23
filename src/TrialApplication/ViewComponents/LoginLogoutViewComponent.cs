using Microsoft.AspNetCore.Mvc;

namespace TrialApplication.ViewComponents
{
    public class LoginLogoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
