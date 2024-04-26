using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models.SQL;
using WolneLekturyCwiczenia.Models.SQL.Table;

namespace WolneLekturyCwiczenia.Controllers
{
    public class KlikController : Controller
    {
        public ISQL _bazadanych = new SQLProvider();
        public IActionResult Go(int AudioId)
        {
            Clicks klik = new Clicks(); 

            klik.ClickDate = DateTime.Now;
            klik.Browser = HttpContext.Request.Headers["User-Agent"];
            klik.AudiobookId = AudioId.ToString();           
            
            _bazadanych.CreateClick(klik);
            
            

            return RedirectToAction("Details", "Audiobook", new { AudioId=AudioId});
        }
    }
}
