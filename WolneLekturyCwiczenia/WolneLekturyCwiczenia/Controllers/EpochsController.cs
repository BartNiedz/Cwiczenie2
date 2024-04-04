using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models;
using WolneLekturyCwiczenia.Models.Data;

namespace WolneLekturyCwiczenia.Controllers
{
    public class EpochsController : Controller
    {
        private IDataRepository _data;
        public EpochsController(IDataRepository data)
        {
            _data = data;

        }
        public async Task<IActionResult> Epochs()
        {
            var epochs = await _data.GetEpochs();

            return View(epochs);
        }

        // Epochs/EpochsAudiobooks?epoka=
        public async Task<IActionResult> EpochsAudiobooks(string epoka) 
        { 
            var audiobooks = await _data.GetAudiobooks();
                        
            IEnumerable<Audiobooks> query = audiobooks.Where(audiobooks =>  audiobooks.epoch == epoka);

            return View(query);
        }
    }
}
