using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models;
using WolneLekturyCwiczenia.Models.Data;
using WolneLekturyCwiczenia.Models.SQL;
using WolneLekturyCwiczenia.Models.SQL.Table;

namespace WolneLekturyCwiczenia.Controllers
{
    public class KategorieController : Controller
    {
        private IDataRepository _data;
        public ISQL _bazadanych = new SQLProvider();

        public async Task InsertCategoryAsync()
        {
            List<Categories> categoryListy = await _data.GetCategories();
            foreach (Categories category in categoryListy)
            {
                Category category1 = new Category();
                category1.Url = category.url;
                category1.Name = category.name;
                category1.Slug = category.slug;
                category1.Href = category.href;

                _bazadanych.CreateCategory(category1);
            }
        }
        public KategorieController(IDataRepository data)
        {
            _data = data;

        }


        // kategorie/index 
    
        public IActionResult Index(int page = 1)
        {            
            int take = 6;
            int skip = (page - 1) * take;

            var listakategorii = _bazadanych.GetCategory();

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

            ViewBag.Content = tresc;

            
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
