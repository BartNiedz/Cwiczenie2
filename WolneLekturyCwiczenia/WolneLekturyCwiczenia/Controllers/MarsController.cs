using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models;
using WolneLekturyCwiczenia.Models.Data;

namespace WolneLekturyCwiczenia.Controllers
{
    public class MarsController : Controller
    {
        private IDataRepository _data;

        public MarsController(IDataRepository data)
        {
            _data = data;
        }
        public async Task<IActionResult> Index()
        {
            Mars mars = await _data.GetMars();

            return View(mars);
        }
    }
}
