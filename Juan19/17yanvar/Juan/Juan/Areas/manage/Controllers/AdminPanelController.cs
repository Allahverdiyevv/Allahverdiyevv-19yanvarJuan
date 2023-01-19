using Microsoft.AspNetCore.Mvc;

namespace Juan.Areas.manage.Controllers
{
    [Area("Manage")]
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
