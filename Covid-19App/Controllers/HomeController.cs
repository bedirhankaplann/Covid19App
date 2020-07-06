using Covid_19App.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Covid_19App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            //ViewBag.Turkey = GetApiDataOfTurkey().Where(c => c.Country == "Turkey").ToList();

            ViewBag.Turkey = GetApiDataOfTurkey();
            //ViewBag.World = GetApiDataOfWorld().ToList();

            // var model = GetApiData().ToList();

            //model.Reverse();



            return View();
        }
        public ActionResult Italy()
        {
            return View();
        }

        public List<TurkeyModel> GetApiDataOfTurkey()
        {
            var apiURL = "https://api.covid19api.com/dayone/country/turkey";

            Uri url = new Uri(apiURL);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer serializeTR = new JavaScriptSerializer();
            List<TurkeyModel> jsonList = serializeTR.Deserialize<List<TurkeyModel>>(json);
            //END

            return jsonList;
        }
        public List<CountryModel> GetApiDataOfWorld()
        {
            var apiURL = "https://api.covid19api.com/summary";

            Uri url = new Uri(apiURL);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer serialize = new JavaScriptSerializer();
            List<CountryModel> jsonList = serialize.Deserialize<List<CountryModel>>(json);
            //END

            return jsonList;
        }
    }
}