using Microsoft.AspNetCore.Mvc;
using Hangfire;

namespace HikingGearShop.OrderService.Controllers
{
    public class SchedualedJobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
