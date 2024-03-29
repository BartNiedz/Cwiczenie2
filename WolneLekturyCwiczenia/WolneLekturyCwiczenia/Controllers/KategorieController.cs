using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models.Data;

namespace WolneLekturyCwiczenia.Controllers
{
    public class KategorieController : Controller
    {
        private IDataRepository _data;

        public KategorieController(IDataRepository data)
        {
            _data = data;

        }

        // kategorie/index
        public async Task<IActionResult> Index()
        {
            var listakategorii = await _data.GetCategories();

            return View(listakategorii);
        }

    
    }
}
