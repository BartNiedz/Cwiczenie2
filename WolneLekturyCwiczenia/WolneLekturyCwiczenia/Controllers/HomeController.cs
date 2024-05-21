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
            Asd asd = new Asd(5, 6);

            int wynik = asd.Add();

            int wynikMnozenia = asd.Multiply();

            double wynikDzielenia = asd.Divide();

            // klasa Person
            Person person = new Person("piotr", "nowak", new DateTime(2001, 04, 11));


            DateTime date = new DateTime(2001, 04, 11);

            int wiek = person.GetAge();

            string imie = person.Name();
            // dzieci
            Person dziecko1 = new Person("Ania", "Kowal", new DateTime(2012, 09, 08));                       
            Person dziecko2 = new Person("Basia", "Nowak", new DateTime(2014, 01, 02));            
            Person dziecko3 = new Person("Rafa³", "Mickiewicz", new DateTime(2017, 04, 12));

            
            person.AddChild(dziecko1);
            person.AddChild(dziecko2);
            person.AddChild(dziecko3); 

            //pracownicy
            Person pracownik1 = new Person("Adam", "Wiœniewski", new DateTime (1998,09,04));
            Person pracownik2 = new Person("Jacek", "Lewandowski", new DateTime(1987, 05, 16));
            Person pracownik3 = new Person("Karolina", "D¹browska", new DateTime(1994, 04, 01));
            
            person.AddEmployee(pracownik1);
            person.AddEmployee(pracownik2);
            person.AddEmployee(pracownik3);
            
            //klienci
            Person klient1 = new Person("Joanna", "Wójcik", new DateTime(1978, 03, 21));
            Person klient2 = new Person("Kamil", "Kamiñski", new DateTime(1965, 05, 20));
            Person klient3 = new Person("Artur", "Wróblewski", new DateTime(1971, 07, 07));

            person.AddCustomer(klient1);
            person.AddCustomer(klient2);
            person.AddCustomer(klient3);

            //klasa Prostokat          
            //Prostokat prostokat = new Prostokat(10, 21);

            //int polePowierzchni = prostokat.PP();

            //int obwod = prostokat.Obw();

            //int longer = prostokat.Longer();

            //klasa ProstokatBC
            ProstokatBC prostokatBC = new ProstokatBC();
            int x = 5;
            int y = 5;
            int polePow = prostokatBC.Pole();
            int obw = prostokatBC.Obwod();
            

            //klasa Trojkat
            Trojkat trojkat = new Trojkat(5, 7, 6);

            int poleTrojkata = trojkat.Pole();

            int obwTrojkata = trojkat.Obw();

            int qwe = prostokatBC.Pole();
            prostokatBC.x = 5;
            prostokatBC.y = 5;


            //Trojkat bez konstruktora

            int _a = 5;
            int _b = 7;
            int _h = 6;

            int ppTrojkata = (_a * _h) / 2;
            int obwodTrojkata = (2 * _b) + _a;

            //klasa Klient
          //  Klient klient6 = new Klient("Adam", "Nowak", "PKO BP");

          //  string nazwaBanku = klient6.BankName();
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
