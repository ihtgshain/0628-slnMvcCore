using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using prjMvcCore.Models;
using Microsoft.AspNetCore.Hosting;
using prjMvcCore.ViewModels;
using System.IO;

namespace prjMvcCore.Controllers
{
    public class ProductController : Controller
    {
        dbDemoContext db = new dbDemoContext();
        private IWebHostEnvironment _enviroment;
        
        public ProductController(IWebHostEnvironment e)
        {
            _enviroment = e;
        }

        public IActionResult List(CKeyWordViewModel v)
        {
            List<TProduct> list = null;
            if (string.IsNullOrEmpty(v.txtKeyword))
                list = db.TProducts.ToList();
            else
                list = db.TProducts.Where(x => x.FName.Contains(v.txtKeyword)).ToList();

            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TProduct p)
        {
            db.TProducts.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            TProduct p=db.TProducts.FirstOrDefault(x => x.FId == id);
            if (p != null)
            {
                db.TProducts.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            var p = db.TProducts.FirstOrDefault(x => x.FId == id);
            return View(p);
        }
        [HttpPost]
        public IActionResult Edit(CProductViewModel p)
        {
            var temp = db.TProducts.FirstOrDefault(x => x.FId == p.FId);
            if (p.photo != null)
            {
                string pName = Guid.NewGuid().ToString() + ".jpg";
                p.photo.CopyTo(new FileStream(_enviroment.WebRootPath + "/Images/" + pName,FileMode.Create));
                temp.FImagePath = pName;
            }
            temp.FName = p.FName;
            temp.FCost = p.FCost;
            temp.FPrice = p.FPrice;
            temp.FQty = p.FQty;

            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
