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
    }
}