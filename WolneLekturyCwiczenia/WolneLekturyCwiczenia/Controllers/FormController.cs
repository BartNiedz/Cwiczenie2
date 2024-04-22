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
            return View();
        }

        [HttpPost]
        public IActionResult FormView(FormData data)
        {
            string email = data.email;
            string firstName = data.firstName;
            string lastName = data.lastName;
            string textarea = data.textarea;

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
