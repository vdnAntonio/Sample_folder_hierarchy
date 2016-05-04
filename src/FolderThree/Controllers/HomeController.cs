using Microsoft.AspNet.Mvc;

namespace FolderThree.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Index.cshtml");
        }
    }
}
