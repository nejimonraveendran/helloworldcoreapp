using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using helloworld.Models;
using System.IO;

namespace helloworld.Controllers
{
    public class Input
    {
        public string Text { get; set; }
    }

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("/api/file")]
        public string CreateFile(Input input)
        {
            var request = Request.Body;

            var fileName = Guid.NewGuid().ToString() + ".txt";
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine(input.Text);
            }

            return fileName;
        }


        [HttpGet("/api/file/{id}")]
        public string ReadFile(string id)
        {
            using (var reader = new StreamReader(id))
            {
                return reader.ReadToEnd();
            }

        }


    }
}
