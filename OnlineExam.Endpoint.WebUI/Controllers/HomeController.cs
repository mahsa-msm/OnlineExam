using Microsoft.AspNetCore.Mvc;

namespace OnlineExam.Endpoint.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}