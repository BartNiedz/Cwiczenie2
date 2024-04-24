using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models;
using WolneLekturyCwiczenia.Models.SQL;
using WolneLekturyCwiczenia.Models.SQL.Table;

namespace WolneLekturyCwiczenia.Controllers
{
    public class FormController : Controller
    {
        public ISQL _bazadanych = new SQLProvider();
        public IActionResult FormView()
        {
            List<Formularz> formList = _bazadanych.GetFormularz();
            return View(formList);
        }

        [HttpPost]
        public IActionResult FormView(Formularz data)
        {
            string email = data.Email;
            string firstName = data.FirstName;
            string lastName = data.LastName;
            string textarea = data.Textarea;

            //test wysylania treści do bazy danych
                       
                Formularz formularz = new Formularz();
                formularz.Date = DateTime.Now;
                formularz.Email = email;
                formularz.FirstName = firstName;
                formularz.LastName = lastName;
                formularz.Textarea = textarea;

                _bazadanych.CreateFormularz(formularz);
            
            
     
            return RedirectToAction("FormSent", "Form");
        }
        public IActionResult FormSent()
        {

        
            return View();
        }
    }
}
