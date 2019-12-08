using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_core_dotnet_core.Controllers
{

    [EnableCors("AllowAllOrigins")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
