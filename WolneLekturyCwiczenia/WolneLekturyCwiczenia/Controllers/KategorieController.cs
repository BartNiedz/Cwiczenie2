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

            ViewBag.LiczbaStron = pageCount;
            ViewBag.Next = page + 1;
            ViewBag.Previous = page - 1;


            return View(strona);
        }
        // Kategorie/KategorieAudiobooks?epoka=
        public async Task<IActionResult> KategorieAudiobooks(string kategoria)
        {
            var audiobooks = await _data.GetAudiobooks();

            IEnumerable<Audiobooks> query = audiobooks.Where(audiobooks => audiobooks.genre == kategoria);

            return View(query);
        }

    }
}
