using AffiliateNetwork.App.Models;
using Microsoft.AspNetCore.Mvc;
using WolneLekturyCwiczenia.Models.SQL;
using WolneLekturyCwiczenia.Models.SQL.Table;

namespace WolneLekturyCwiczenia.Controllers
{
    public class CategoryJSController : Controller
    {
        public ISQL _bazadanych = new SQLProvider();
        public IActionResult CategoryJSIndex()
        {
            return View();
        }
        public JsonResult _GetCategory(DTParameters model)
        {
            int page = (model.Start / model.Length) + 1;
            List<Category> categoryjs = _bazadanych.GetCategoryJS(model.Length, page);
            int a = _bazadanych.GetCategoryElementCount();
            DataTableModel m = new DataTableModel()
            {
                data = categoryjs,
                recordsFiltered = a,
                recordsTotal = a,
                draw = model.Draw
            };

            return Json(m);
        }
    }
}
