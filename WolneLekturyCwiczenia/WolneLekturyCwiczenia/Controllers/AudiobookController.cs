
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WolneLekturyCwiczenia.Models;
using WolneLekturyCwiczenia.Models.Data;
using WolneLekturyCwiczenia.Models.SQL;
using WolneLekturyCwiczenia.Models.SQL.Table;

namespace WolneLekturyCwiczenia.Controllers
{
    public class AudiobookController : Controller
    {
        private IDataRepository _data;
        public ISQL _bazadanych = new SQLProvider();
        public async Task InsertAudioAsync()
        {
            List<Audiobooks> audioListy = await _data.GetAudiobooks();
            foreach (Audiobooks audio in audioListy)
            {
                Audio audio1 = new Audio();
                audio1.Kind = audio.kind;
                audio1.Full_sort_key = audio.full_sort_key;
                audio1.Title = audio.title;
                audio1.Url = audio.url;
                audio1.Cover_color = audio.cover_color;
                audio1.Author = audio.author;
                audio1.Cover = audio.cover;
                audio1.Epoch = audio.epoch;
                audio1.Href = audio.href;                
                audio1.Genre = audio.genre;
                audio1.Simple_thumb = audio.simple_thumb;
                audio1.Slug = audio.slug;
                audio1.Cover_thumb = audio.cover_thumb;



                _bazadanych.CreateAudio(audio1);
            }
        }
        public AudiobookController(IDataRepository data)
        {
            _data = data;

        }

        //audiobook/audiobooks?page=1
        public IActionResult Audiobooks(int page = 1)
        {
            
            int take = 12;
            int skip = (page - 1) * take;            
            List<Audio> audiobooks = _bazadanych.GetAudioDB();
                      
            List<Audio> strona = audiobooks.Skip(skip).Take(take).ToList();
            
            //int allCount = audiobooks.Count();
            //int pageCount = (allCount / take) + 1;
            int pageCount = (audiobooks.Count() / take) + 1;

            ViewBag.PageNumber = page;

            ViewBag.PageCount = pageCount;

            ViewBag.NastepnaStrona = page +1;

            ViewBag.PoprzedniaStrona = page -1;


            List<Epoch> listaEpok = _bazadanych.GetEpochsDB();

            ViewBag.ListaEpok = listaEpok;

            List<Category> listaKategorii = _bazadanych.GetCategory();

            ViewBag.ListaKategorii = listaKategorii;




            return View(strona);
        }
                

        [HttpPost]
        public IActionResult Audiobooks(string szukaj, string epoki, string kategorie)
        {

            List<Category> listaKategorii = _bazadanych.GetCategory();

            ViewBag.ListaKategorii = listaKategorii;

            ViewBag.Szukaj = szukaj;
            ViewBag.Epoki = epoki;  
            ViewBag.Kategorie = kategorie;


            List<Epoch> listaEpok = _bazadanych.GetEpochsDB();

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
            List<Audio> lista = _bazadanych.GetAudioDB();
            List<Audio> filtr = lista.Where(lista => lista.Title.ToLower().Contains(szukaj.ToLower())).Where(x => x.Epoch.Contains(epoki)).Where(y => y.Genre.Contains(kategorie)).ToList();




                return View(filtr);
            
        }
        

        //audiobook/details
        public IActionResult Details(int AudioId /*string detale*/)
        {
            //metoda where nie pobierająca całej bazy danych

            //var kawa = _bazadanych.GetAudioDB().Where(x => x.AudioId == id);
            //IEnumerable<Audio> kawa = audiobooks.Where(z => z.Slug == detale);
           var kawa = _bazadanych.GetDetails(AudioId);

            //dotychczasowa metoda 
            //var audiobooks = _bazadanych.GetAudioDB();
            //Audio kawa = audiobooks.First(audiobooks => audiobooks.Slug == detale);

            return View(kawa);
        }
        public IActionResult NewAudio() 
        {
            return View(); 
        }
        public IActionResult AddAudio(Audio audio)
        {
            _bazadanych.CreateAudio(audio);

            return RedirectToAction("Audiobooks", "Audiobook");
        }
        public IActionResult EditFormAudio(int audioid)
        {
            Audio audio = _bazadanych.Get2Audio(audioid);
            return View(audio);
        }
        public IActionResult EditAudio(Audio audio)
        {
            _bazadanych.EditAudio(audio);

            return RedirectToAction("Audiobooks", "Audiobook");
        }

    }
}
