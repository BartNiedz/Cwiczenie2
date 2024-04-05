using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Audiobooks(int page)
        {
            int take = 12;
            int skip = (page - 1) * take;            
            List<Audiobooks> audiobooks = await _data.GetAudiobooks();
                      
            List<Audiobooks> strona = audiobooks.Skip(skip).Take(take).ToList();
           
            return View(strona);
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
