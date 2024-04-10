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
          

                       
       
            
            
           
            return View(strona);
        }

        public async Task<IActionResult> Audiobooks(string select)
        {
            List<Epochs> lista = await _data.GetEpochs();
            
            ViewBag.ListaEpok = lista;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Audiobooks(string szukaj)
        {
            List<Audiobooks> lista = await _data.GetAudiobooks();
            List<Audiobooks> filtr = lista.Where(lista => lista.title.ToLower().Contains(szukaj.ToLower())).ToList();

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
