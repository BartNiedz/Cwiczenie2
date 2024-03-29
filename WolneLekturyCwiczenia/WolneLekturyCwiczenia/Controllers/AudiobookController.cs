using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Audiobooks()
        {
            var audiobooks = await _data.GetAudiobooks();

            return View(audiobooks);
        }
    }
}
