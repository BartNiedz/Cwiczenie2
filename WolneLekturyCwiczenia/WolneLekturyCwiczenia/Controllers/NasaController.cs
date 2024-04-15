using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models;
using WolneLekturyCwiczenia.Models.Data;

namespace WolneLekturyCwiczenia.Controllers
{
    public class NasaController : Controller
    {
        private IDataRepository _data;

        public NasaController(IDataRepository data)
        {
            _data = data;
        }
        public async Task<IActionResult> Index()
        {
            Nasa nasa = await _data.GetNasa();

            return View(nasa);
        }
    }
}
