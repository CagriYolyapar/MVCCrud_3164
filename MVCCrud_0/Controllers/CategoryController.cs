using MVCCrud_0.DesignPatterns.SingletonPattern;
using MVCCrud_0.Models;
using MVCCrud_0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrud_0.Controllers
{
    public class CategoryController : Controller
    {
        //Route  => url


        //  {controller} / {action} => Burası baz kısım
        // routeValue => Baz kısımdan sonra gelen onun dısında kalan her yer




        NorthwindEntities _db;

        public CategoryController()
        {
            _db = DBTool.DBInstance;
        }
        public ActionResult ListCategories()
        {
            List<CategoryVM> categories = _db.Categories.Select(x => new CategoryVM
            {
                ID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();
            return View(categories);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryVM cvm)
        {
            //Bir class'ı (buradaki Entity class'ımızı) bir VM class'ına cevirme veya bir VM'i bir Entity'e cevirme işlemine Mapping denir...
            Category c = new Category
            {
                CategoryName = cvm.CategoryName,
                Description = cvm.Description
            };

            _db.Categories.Add(c);
            _db.SaveChanges();


            return RedirectToAction("ListCategories");

        }


        public ActionResult UpdateCategory(int id)
        {
            CategoryVM cvm = _db.Categories.Select(x => x.CategoryID == id).FirstOrDefault();
            return View();
        }
    }
}