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
        //Epochs/Epochs
        public async Task<IActionResult> Epochs(int page = 1 )
        {
            int take = 6;
            int skip = (page - 1) * take;
            var epochs = await _data.GetEpochs();
            var strona = epochs.Skip(skip).Take(take).ToList();
            int pageCount = (epochs.Count() / take) + 1;
            ViewBag.PageNumber = page;
            ViewBag.PageCountEpochs = pageCount;
            ViewBag.NextPageEpochs = page + 1;
            ViewBag.PreviousPageEpochs = page - 1;

            return View(strona);
        }

        [HttpPost]
        public async Task<IActionResult> Epochs(string tresc)
        {
            if (string.IsNullOrEmpty(tresc))
            {
                tresc = string.Empty;
            }
            List<Epochs> epochs = await _data.GetEpochs();
            List<Epochs> filtr = epochs.Where(cos => cos.name.ToLower().Contains(tresc.ToLower())).ToList();

            ViewBag.Content = tresc;

            return View(filtr);
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
