using AffiliateNetwork.App.Models;
using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models.Data;
using WolneLekturyCwiczenia.Models.SQL;
using WolneLekturyCwiczenia.Models.SQL.Table;

namespace WolneLekturyCwiczenia.Controllers
{
    public class EpochsJSController : Controller
    {
        
        public ISQL _bazadanych = new SQLProvider();
        public IActionResult EpochsJSIndex()
        {  
            return View();
        }

        public JsonResult _GetEpochs(DTParameters model)
        {
            int page = (model.Start / model.Length) + 1;
            List<Epoch> epochjs= _bazadanych.GetEpochJS(model.Length, page);            
            int a = _bazadanych.GetEpochElementCount();
            DataTableModel m = new DataTableModel()
            {
                data = epochjs,
                recordsFiltered = a,
                recordsTotal = a,
                draw = model.Draw
            };

            return Json(m);
        }
    }
}
