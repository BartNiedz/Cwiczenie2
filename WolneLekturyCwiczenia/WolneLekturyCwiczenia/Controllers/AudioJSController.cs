using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models.Data;
using WolneLekturyCwiczenia.Models.SQL;
using WolneLekturyCwiczenia.Models.SQL.Table;

namespace WolneLekturyCwiczenia.Controllers
{
    public class AudioJSController : Controller
    {
        private IDataRepository _data;
        public ISQL _bazadanych = new SQLProvider();
        public IActionResult Index()
        {
            List<Audio> audiojs = _bazadanych.GetAudioJS();
            return View(audiojs);
        }
        public AudioJSController(IDataRepository data)
        {
            _data = data;
        }
    }
}
