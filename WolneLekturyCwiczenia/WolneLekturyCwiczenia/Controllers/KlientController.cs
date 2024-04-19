using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models;

namespace WolneLekturyCwiczenia.Controllers
{
    public class KlientController : Controller
    {
        public IActionResult Index()
        {
            BankAccount b = new BankAccount();
            b.Bank_name = "PKO";
            b.Account_number = "12312312312312312312312";

            Klient klient1 = new Klient("Adam", "Nowak", b);

            string nazwaBanku = klient1.BankName();


            return View(klient1);
        }

    }
}
