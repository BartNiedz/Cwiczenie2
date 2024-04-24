using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models;
using WolneLekturyCwiczenia.Models.Data;
using WolneLekturyCwiczenia.Models.SQL;
using WolneLekturyCwiczenia.Models.SQL.Table;

namespace WolneLekturyCwiczenia.Controllers
{
    public class EpochsController : Controller
    {
        private IDataRepository _data;
        public ISQL _bazadanych = new SQLProvider();

        public async Task InsertEpochAsync()
        {
            List<Epochs> epochListy = await _data.GetEpochs();
            foreach (Epochs epoch in epochListy)
            {
                Epoch epoch1 = new Epoch();
                epoch1.Url = epoch.url;
                epoch1.Name = epoch.name;
                epoch1.Slug = epoch.slug;
                epoch1.Href = epoch.href;

                _bazadanych.CreateEpoch(epoch1);
            }
        }
        public EpochsController(IDataRepository data)
        {
            _data = data;

        }
        //Epochs/Epochs
        public IActionResult Epochs(int page = 1 )
        {
            int take = 6;
            int skip = (page - 1) * take;
            var epochs = _bazadanych.GetEpochsDB();
            var strona = epochs.Skip(skip).Take(take).ToList();
            int pageCount = (epochs.Count() / take) + 1;
            ViewBag.PageNumber = page;
            ViewBag.PageCountEpochs = pageCount;
            ViewBag.NextPageEpochs = page + 1;
            ViewBag.PreviousPageEpochs = page - 1;

            return View(strona);
        }

        [HttpPost]
        public IActionResult Epochs(string tresc)
        {
            if (string.IsNullOrEmpty(tresc))
            {
                tresc = string.Empty;
            }
            List<Epoch> epochs = _bazadanych.GetEpochsDB();
            List<Epoch> filtr = epochs.Where(cos => cos.Name.ToLower().Contains(tresc.ToLower())).ToList();

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
