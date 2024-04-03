using Microsoft.AspNetCore.Mvc;
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
    }
}
