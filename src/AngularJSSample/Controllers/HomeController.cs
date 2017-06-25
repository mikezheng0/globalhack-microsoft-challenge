using AngularJSSample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AngularSample.Controllers
{

    public class HomeController : Controller
    {
        private string _jsonString;
        private byte[] _receivedImg;
        public async Task getJsonFromImg()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "788594a1e9a445f8b1885d61dc5a01ad");
            string uri = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?";
            HttpResponseMessage response;
            using (var content = new ByteArrayContent(_receivedImg))
            {
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                _jsonString = response.Content.ReadAsStringAsync().Result;
            }
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CameraData value)
        {

            if (value == null)
            {
                return BadRequest();
            }
            _receivedImg = Convert.FromBase64String(value.Data);
            await getJsonFromImg();
            
            return CreatedAtRoute("Get", new { id = value.Data }, value);
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