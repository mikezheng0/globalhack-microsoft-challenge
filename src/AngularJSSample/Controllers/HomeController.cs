using AngularJSSample.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AngularSample.Controllers
{

    public class HomeController : Controller
    {
        private Emotion[] lastRecordedEmotion;
        private Emotion willSaveEmo;
        private DateTime willSaveTime;
        private bool lastFrameFull = false;
        private byte[] willSaveImg;
        private int largestArea = 0;
        private byte[] _receivedImg;
        public async Task getJsonFromImg()
        {
            // Sends a request to the Emotion API
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "788594a1e9a445f8b1885d61dc5a01ad");
            string uri = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?";
            HttpResponseMessage response;
            using (var content = new ByteArrayContent(_receivedImg))
            {
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);

                // Stores the Emotion
                string _jsonString = response.Content.ReadAsStringAsync().Result;
                lastRecordedEmotion = JsonConvert.DeserializeObject<Emotion[]>(_jsonString);

                // Finds the Face with the largest area, and saves it with willSave...
                foreach (Emotion e in lastRecordedEmotion) {
                    if (e.rectangle.Height * e.rectangle.Width > largestArea) {
                        largestArea = e.rectangle.Height * e.rectangle.Width;
                        willSaveEmo = e;
                        willSaveTime = DateTime.Now;
                        willSaveImg = _receivedImg;
                    }
                }

                // Save to database once no on is in frame and reinitialize variables
                if (lastRecordedEmotion.Length == 0 && largestArea > 0) {
                    largestArea = 0;
                    willSaveEmo = null;
                    willSaveImg = null;
                }
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