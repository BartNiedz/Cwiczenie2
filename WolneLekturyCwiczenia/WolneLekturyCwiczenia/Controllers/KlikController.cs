using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models;

namespace WolneLekturyCwiczenia.Controllers
{
    public class KlikController : Controller
    {
        public IActionResult Go(string slug)
        {
            Klik klik = new Klik(); 
            klik.clickData = DateTime.Now;
            klik.browser = HttpContext.Request.Headers["User-Agent"];
            klik.audiobookID = slug;

            return RedirectToAction("Details", "Audiobook", new { detale=slug});
        }
    }
}
