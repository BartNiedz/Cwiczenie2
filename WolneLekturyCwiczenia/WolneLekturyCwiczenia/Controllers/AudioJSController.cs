﻿using AffiliateNetwork.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WolneLekturyCwiczenia.Models;
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
            
            
            FiltrAudio audiojs = _bazadanych.GetAudioSP(5 , 1, "Antek");

            

            return View(audiojs);
        }

        //audiojs/_getaudiobooks
        public JsonResult _GetAudiobooks(DTParameters model)
        {
            int page = (model.Start / model.Length)+1;
            List<Audio> audiojs = _bazadanych.GetAudioJS(50, page);

            int a = _bazadanych.GetElementCount();
            DataTableModel m = new DataTableModel()
            {
                data= audiojs,
                recordsFiltered=a,
                recordsTotal=a,
                draw= model.Draw
            };

            return Json(m);
        }



        public AudioJSController(IDataRepository data)
        {
            _data = data;
        }
    }
}
