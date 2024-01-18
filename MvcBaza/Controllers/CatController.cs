using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcBaza.Controllers
{
    public class CatController : Controller
    {
        
        // GET: /Cat/
        
        public IActionResult Index()
        {
            return View();
        }
        
        // 
        // GET: /Cat/Welcome/ 
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
    }
}
