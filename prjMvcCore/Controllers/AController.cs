using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjLottoApp.Models;
using prjMvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace prjMvcCore.Controllers
{
    public class AController : Controller
    {
        dbDemoContext db = new dbDemoContext();
        public IActionResult Index()
        {
            return View();
        }
        public string sayHello()
        {
            return "Hello ASP.NET MVC";
        }

        public string lotto()
        {   
            return (new CLottoGen()).getLotto();
        }

        public ActionResult showCountBySession()
        {
            int count = 0;

            if (HttpContext.Session.Keys.Contains("KK"))
                count = (int)HttpContext.Session.GetInt32("KK");

            count++;
            HttpContext.Session.SetInt32("KK", count);
            ViewBag.count = count;
            return View();
        }
        public string demoObject2Json()
        {
            TProduct x = db.TProducts.FirstOrDefault(x => true);
            return JsonSerializer.Serialize(x);
        }

        public string demoJson2Object()
        {
            string j = demoObject2Json();
            TProduct x = JsonSerializer.Deserialize<TProduct>(j);
            return x.FName + "/" + x.FPrice.ToString();
        }
    }
}
