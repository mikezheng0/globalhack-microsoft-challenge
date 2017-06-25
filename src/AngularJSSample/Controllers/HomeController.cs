using AngularJSSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post([FromBody]CameraData value)
        {

          if (value == null)
          {
            return BadRequest();
          }

          return CreatedAtRoute("Get", new { id = value.Data}, value);
        }

    public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        public IActionResult Directives()
        {
            return View();
        }

        public IActionResult Databinding()
        {
            return View();
        }

        public IActionResult Templates()
        {
            return View();
        }

        public IActionResult Expressions()
        {
            return View();
        }
        public IActionResult Repeaters()
        {
            return View();
        }

        public IActionResult Repeaters2()
        {
            return View();
        }

        public IActionResult Scope()
        {
            return View();
        }

        public IActionResult Controllers()
        {
            return View();
        }

        public IActionResult Components()
        {
            return View();
        }

        public IActionResult PersonComponent()
        {
            return View();
        }
    }
}