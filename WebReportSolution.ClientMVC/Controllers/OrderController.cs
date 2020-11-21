using Microsoft.AspNetCore.Mvc;

namespace WebReportSolution.ClientMVC.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
