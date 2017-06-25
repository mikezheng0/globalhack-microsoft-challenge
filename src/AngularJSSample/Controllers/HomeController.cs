using AngularJSSample.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AngularSample.Controllers
{

    public class HomeController : Controller
    {
        private Emotion[] lastRecordedEmotion;
        private byte[] _receivedImg;
        public async Task<Emotion[]> getJsonFromImg()
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
                    if (HttpContext.Session.GetInt32("largestArea") == null || e.FaceRectangle.Height * e.FaceRectangle.Width > HttpContext.Session.GetInt32("largestArea")) {
                        HttpContext.Session.SetInt32("largestArea", e.FaceRectangle.Height * e.FaceRectangle.Width);
                        
                        HttpContext.Session.SetObjectAsJson("willSaveEmo", e);
                        HttpContext.Session.SetObjectAsJson("willSaveTime", DateTime.Now);
                        HttpContext.Session.SetObjectAsJson("willSaveImg", _receivedImg);
                    }
                }
                // Save to database once no on is in frame and reinitialize variables
                if (HttpContext.Session.GetInt32("largestArea") != null && lastRecordedEmotion.Length == 0 && HttpContext.Session.GetInt32("largestArea") > 0) {
                    Emotion emote = HttpContext.Session.GetObjectFromJson<Emotion>("willSaveEmo");
                    _context.Add(new Interaction {
                        Time = HttpContext.Session.GetObjectFromJson<DateTime>("willSaveTime"),
                        Image = HttpContext.Session.GetObjectFromJson<byte[]>("willSaveImg"),
                        Anger = emote.Scores.Anger,
                        Sadness = emote.Scores.Sadness,
                        Fear = emote.Scores.Fear,
                        Contempt = emote.Scores.Contempt,
                        Happiness = emote.Scores.Happiness,
                        Surprise = emote.Scores.Surprise,
                        Disgust = emote.Scores.Disgust,
                        Neutral = emote.Scores.Neutral,
                        Left = emote.FaceRectangle.Left,
                        Width = emote.FaceRectangle.Width,
                        Top = emote.FaceRectangle.Top,
                        Height = emote.FaceRectangle.Height,

                    });
                    await _context.SaveChangesAsync();
                    HttpContext.Session.Clear();    
                    // TODO save to database
                }
                return lastRecordedEmotion;
            }
        }

        [Route("home/todayinteractions/")]
        public async Task<JsonResult> GetTodaysInteractions()
        {
            EmotionAnalytics emote = new EmotionAnalytics();
            emote.Anger = _context.Interaction.Where(a => a.Anger > EmotionAnalytics.THRESHOLD).Count();
            emote.Neutral = _context.Interaction.Where(a => a.Neutral > EmotionAnalytics.THRESHOLD).Count();
            emote.Surprise = _context.Interaction.Where(a => a.Surprise > EmotionAnalytics.THRESHOLD).Count();
            emote.Happiness = _context.Interaction.Where(a => a.Happiness > EmotionAnalytics.THRESHOLD).Count();
            emote.Fear = _context.Interaction.Where(a => a.Fear > EmotionAnalytics.THRESHOLD).Count();
            emote.Sadness = _context.Interaction.Where(a => a.Sadness > EmotionAnalytics.THRESHOLD).Count();
            emote.Contempt = _context.Interaction.Where(a => a.Contempt > EmotionAnalytics.THRESHOLD).Count();
            emote.Disgust = _context.Interaction.Where(a => a.Disgust > EmotionAnalytics.THRESHOLD).Count();

            return new JsonResult (emote);
        }

        [Route("home/emotiontime/")]
        public async Task<JsonResult> GetEmotionPercentageTime()
        {
            EmotionTimeCollection emoteTimes = new EmotionTimeCollection();
            emoteTimes.Emotions = new List<EmotionTime>();
            var j = 0;
            string query = "select ";
            for (int i = 4; i < 24; i += 4)
            {
                query += $"(Select count(*) From Interaction Where Time > '{DateTime.Now.AddHours(-i)}' AND Time< '{DateTime.Now.AddHours(-(j * 4))}' AND Happiness > 0.60000) as happy{i},";
                query += $"(Select count(*) From Interaction Where Time > '{DateTime.Now.AddHours(-i)}' AND Time< '{DateTime.Now.AddHours(-(j * 4))}' AND Anger > 0.60000) as anger{i},";
                query += $"(Select count(*) From Interaction Where Time > '{DateTime.Now.AddHours(-i)}' AND Time< '{DateTime.Now.AddHours(-(j * 4))}' AND Neutral > 0.60000) as neutral{i}";
                if (j < 4)
                {
                    query += ",";
                }

                j++;
            }

      /*using (var command = _context.Database.GetDbConnection().CreateCommand())
      {
          command.CommandText = query;
          _context.Database.OpenConnection();
          using (var result = command.ExecuteReader())
          {
              while (result.Read())
              {
                  Console.WriteLine(String.Format("{0}", result[0]));
              }
              // do something with result
          }
      }*/
      using (var connection = _context.Database.GetDbConnection())
      {
        connection.Open();

        using (var command = connection.CreateCommand())
        {
          command.CommandText = query;
          using (var result = command.ExecuteReader())
          {
            while (result.Read())
            {
              EmotionTime emoteTime = new EmotionTime();
              emoteTime.EmotionCounts = new EmotionAnalytics();
              emoteTime.HoursAgo = 4;
              emoteTime.EmotionCounts.Happiness = (int)result[0];
              emoteTime.EmotionCounts.Anger = (int)(result[1]);
              emoteTime.EmotionCounts.Neutral = (int)result[2];
              emoteTimes.Emotions.Add(emoteTime);
              emoteTime = new EmotionTime();
              emoteTime.EmotionCounts = new EmotionAnalytics();
              emoteTime.HoursAgo = 8;
              emoteTime.EmotionCounts.Happiness = (int)result[3];
              emoteTime.EmotionCounts.Anger = (int)(result[4]);
              emoteTime.EmotionCounts.Neutral = (int)result[5];
              emoteTimes.Emotions.Add(emoteTime);
              emoteTime = new EmotionTime();
              emoteTime.EmotionCounts = new EmotionAnalytics();
              emoteTime.HoursAgo = 12;
              emoteTime.EmotionCounts.Happiness = (int)result[6];
              emoteTime.EmotionCounts.Anger = (int)(result[7]);
              emoteTime.EmotionCounts.Neutral = (int)result[8];
              emoteTimes.Emotions.Add(emoteTime);
              emoteTime = new EmotionTime();
              emoteTime.EmotionCounts = new EmotionAnalytics();
              emoteTime.HoursAgo = 16;
              emoteTime.EmotionCounts.Happiness = (int)result[9];
              emoteTime.EmotionCounts.Anger = (int)(result[10]);
              emoteTime.EmotionCounts.Neutral = (int)result[11];
              emoteTimes.Emotions.Add(emoteTime);
              emoteTime = new EmotionTime();
              emoteTime.EmotionCounts = new EmotionAnalytics();
              emoteTime.HoursAgo = 20;
              emoteTime.EmotionCounts.Happiness = (int)result[12];
              emoteTime.EmotionCounts.Anger = (int)(result[13]);
              emoteTime.EmotionCounts.Neutral = (int)result[14];
              emoteTimes.Emotions.Add(emoteTime);
            }
            // do something with result
          }
        }

        connection.Close();
      }

      return new JsonResult(emoteTimes);
        }

        private readonly CameraContext _context;

        public HomeController(CameraContext context)
        {
          _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody]CameraData value)
        {

            if (value == null)
            {
                //return BadRequest();
            }
            _receivedImg = Convert.FromBase64String(value.Data);
            Emotion[] emotes = await getJsonFromImg();
            
            return new JsonResult(emotes);
        }


        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

    }
}