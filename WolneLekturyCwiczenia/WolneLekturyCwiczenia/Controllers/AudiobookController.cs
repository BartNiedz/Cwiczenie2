using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WolneLekturyCwiczenia.Models;
using WolneLekturyCwiczenia.Models.Data;

namespace WolneLekturyCwiczenia.Controllers
{
    public class AudiobookController : Controller
    {
        private IDataRepository _data;
        public AudiobookController(IDataRepository data)
        {
            _data = data;

        }

        //audiobook/audiobooks?page=1
        public async Task<IActionResult> Audiobooks(int page = 1)
        {
            
            int take = 12;
            int skip = (page - 1) * take;            
            List<Audiobooks> audiobooks = await _data.GetAudiobooks();
                      
            List<Audiobooks> strona = audiobooks.Skip(skip).Take(take).ToList();
            
            //int allCount = audiobooks.Count();
            //int pageCount = (allCount / take) + 1;
            int pageCount = (audiobooks.Count() / take) + 1;

            ViewBag.PageNumber = page;

            ViewBag.PageCount = pageCount;

            ViewBag.NastepnaStrona = page +1;

            ViewBag.PoprzedniaStrona = page -1;


            List<Epochs> listaEpok = await _data.GetEpochs();

            ViewBag.ListaEpok = listaEpok;

            List<Categories> listaKategorii = await _data.GetCategories();

            ViewBag.ListaKategorii = listaKategorii;




            return View(strona);
        }
                

        [HttpPost]
        public async Task<IActionResult> Audiobooks(string szukaj, string epoki, string kategorie)
        {

            List<Categories> listaKategorii = await _data.GetCategories();

            ViewBag.ListaKategorii = listaKategorii;

            ViewBag.Szukaj = szukaj;
            ViewBag.Epoki = epoki;  
            ViewBag.Kategorie = kategorie;


            List<Epochs> listaEpok = await _data.GetEpochs();

            ViewBag.ListaEpok = listaEpok;

            if (string.IsNullOrEmpty(szukaj))
            {
                szukaj = "";
            }
            if (string.IsNullOrEmpty(epoki))
            {
                epoki = "";
            }
            if (string.IsNullOrEmpty(kategorie))
            {
                kategorie = "";
            }
            List<Audiobooks> lista = await _data.GetAudiobooks();
                List<Audiobooks> filtr = lista.Where(lista => lista.title.ToLower().Contains(szukaj.ToLower())).Where(x => x.epoch.Contains(epoki)).Where(y => y.genre.Contains(kategorie)).ToList();




                return View(filtr);
            
        }
        

        //audiobook/details
        public async Task<IActionResult> Details(string detale)
        {
            var audiobooks = await _data.GetAudiobooks();

            Audiobooks kawa = audiobooks.First(audiobooks => audiobooks.slug == detale);
            
            return View(kawa);
        }
    }
}
