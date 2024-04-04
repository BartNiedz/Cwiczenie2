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

        //audiobook/audiobooks
        public async Task<IActionResult> Audiobooks()
        {
            var audiobooks = await _data.GetAudiobooks();

            return View(audiobooks);
        }

        //audiobook/details
        public async Task<IActionResult> Details(string detale)
        {
            var audiobooks = await _data.GetAudiobooks();

            Audiobooks first = audiobooks.First(audiobooks => audiobooks.slug == detale);

            return View(first);
        }
    }
}
