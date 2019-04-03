using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FilmLibraryCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FilmLibraryCore.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult FilmName()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FilmName(String filmName)
        {
            return RedirectToAction("FilmDetails", "Film", new { filmName = filmName });
        }

        [HttpGet]
        public ActionResult FilmDetails(string filmName)
        {
            string apikey = "45852784";
            string movieURL = "http://www.omdbapi.com/?t=" + filmName + "&apikey=" + apikey;
            string res = "";

            Console.WriteLine(movieURL);

            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(movieURL).Result;

                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                }
            }

            var data = JsonConvert.DeserializeObject<FillmDetails>(res);

            Console.WriteLine(data);

            if (data.Poster != "N.A")
            {
                data.LocalImageName = Regex.Replace(data.Title, @"[^0-9a-zA-Z]+", "") + ".jpg";

                var imagePath = "wwwroot//images//" + data.LocalImageName;

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(data.Poster), imagePath);
                }
            }

            return View(data);
        }
    }
}