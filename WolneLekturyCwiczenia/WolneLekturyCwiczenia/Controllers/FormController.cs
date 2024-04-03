using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models;

namespace WolneLekturyCwiczenia.Controllers
{
    public class FormController : Controller
    {
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

     
            return RedirectToAction("FormSent", "Form");
        }
        public IActionResult FormSent()
        {

        
            return View();
        }
    }
}
