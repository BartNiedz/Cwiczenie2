using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using WolneLekturyCwiczenia.Models;
using WolneLekturyCwiczenia.Models.Data;
using WolneLekturyCwiczenia.Models.SQL;
using WolneLekturyCwiczenia.Models.SQL.Table;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WolneLekturyCwiczenia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IDataRepository _data;
        private ISQL _sql = new SQLProvider();

        public HomeController(ILogger<HomeController> logger, IDataRepository data)
        {
            _logger = logger;
            _data = data;
        }

        public IActionResult Index()
        {
            // klasa Asd
            Asd asd = new Asd(2, 3);

            int wynik = asd.Add();

            int wynikMnozenia = asd.Multiply();

            double wynikDzielenia = asd.Divide();

            // klasa Person
            Person person = new Person("piotr", "nowak", new DateTime(2001, 04, 11));

            DateTime date = new DateTime(2001, 04, 11);

            int wiek = person.GetAge();

            string imie = person.Name();

            Person dziecko1 = new Person("Ania", "Kowal", new DateTime(2012, 09, 08));                       
            Person dziecko2 = new Person("Basia", "Nowak", new DateTime(2014, 01, 02));            
            Person dziecko3 = new Person("Rafa³", "Mickiewicz", new DateTime(2017, 04, 12));

            
            person.AddChild(dziecko1);
            person.AddChild(dziecko2);
            person.AddChild(dziecko3); 
            
            //klasa Prostokat          
            Prostokat prostokat = new Prostokat(10, 21);

            int polePowierzchni = prostokat.PP();

            int obwod = prostokat.Obw();

            int longer = prostokat.Longer();         

            
            // sql
            Testowa t = new Testowa()
            {
                Message = "testa"
            };

            _sql.SaveTestowa(t);

            return View(person);
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
