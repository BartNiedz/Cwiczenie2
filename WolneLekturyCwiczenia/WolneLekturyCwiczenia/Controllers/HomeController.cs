using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using WolneLekturyCwiczenia.Models;
using WolneLekturyCwiczenia.Models.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WolneLekturyCwiczenia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IDataRepository _data;

        public HomeController(ILogger<HomeController> logger, IDataRepository data)
        {
            _logger = logger;
            _data = data;
        }

        public IActionResult Index()
        {
             Asd asd = new Asd(2,3);

             int wynik = asd.Add();

             int wynikMnozenia = asd.Multiply();

            double wynikDzielenia = asd.Divide();



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
        
    }
}
