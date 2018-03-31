using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;


namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<CheeseCategory> cheeseCategories = context.Categories.ToList();
            return View(cheeseCategories);
        }


        public IActionResult Add()
        {
            AddCategoryViewModel addCat = new AddCategoryViewModel();
            return View(addCat);
        }


        [HttpPost]
        public IActionResult Add(AddCategoryViewModel obj)
        {
            if (ModelState.IsValid)
            {
                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = obj.Name
                };
                context.Categories.Add(newCategory); 
                context.SaveChanges();
                return Redirect("/Category");
            }

            return View(obj);
        }
    }
}
