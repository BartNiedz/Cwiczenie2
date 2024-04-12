using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models;
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
        public async Task<IActionResult> Index(int page = 1)
        {            
            int take = 6;
            int skip = (page - 1) * take;

            var listakategorii = await _data.GetCategories();
            var strona = listakategorii.Skip(skip).Take(take).ToList();

            int allCount = listakategorii.Count();
            int pageCount = (allCount / take) + 1;

            ViewBag.Page = page;
            ViewBag.LiczbaStron = pageCount;
            ViewBag.Next = page + 1;
            ViewBag.Previous = page - 1;
            

            return View(strona);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string tresc)
        {
            
            if (string.IsNullOrEmpty(tresc))
            {
              tresc = string.Empty;
            }
            List<Categories> cos = await _data.GetCategories();
            List<Categories> filtr = cos.Where(cos => cos.name.ToLower().Contains(tresc.ToLower())).ToList();
            

            return View(filtr);
        }

        // Kategorie/KategorieAudiobooks?kategoria=
        public async Task<IActionResult> KategorieAudiobooks(string kategoria)
        {
            List<Audiobooks> audiobooks = await _data.GetAudiobooks();

            IEnumerable<Audiobooks> query = audiobooks.Where(audiobooks => audiobooks.genre == kategoria);

            return View(query);
        }

    }
}
