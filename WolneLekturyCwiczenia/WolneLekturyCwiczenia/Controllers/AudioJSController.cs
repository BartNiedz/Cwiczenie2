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
        public IActionResult Index(/*int page = 1*/)
        {
           /* int take = 10;
            int skip = (page -1) * take;*/
            
            List<Audio> audiojs = _bazadanych.GetAudioJS();                   
            /*List<Audio> strona = audiojs.Skip(skip).Take(take).ToList();    
            int allCount = audiojs.Count();
            int pageCount = (allCount / take) + 1;*/


            return View(/*strona*/audiojs);
        }
        public AudioJSController(IDataRepository data)
        {
            _data = data;
        }
    }
}
