using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Products_Categories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Products_Categories{
    public class HomeController : Controller
    {
        private MyContext dbContext;
 
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.products=dbContext.product.ToList();
            return View();
        }

        [HttpPost("create_product")]
        public IActionResult Create_Product(Product product)
        {
            if(ModelState.IsValid)
            {
                dbContext.product.Add(product);
                dbContext.SaveChanges();
                ViewBag.products=dbContext.product.ToList();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet("add_category")]
        public IActionResult Add_Category()
        {
            ViewBag.category=dbContext.categories.ToList();
            return View();
        }

        [HttpPost("create_category")]
        public IActionResult Create_Category(Category category)
        {
            if(ModelState.IsValid)
            {
                dbContext.categories.Add(category);
                dbContext.SaveChanges();
                ViewBag.category=dbContext.categories.ToList();
                return RedirectToAction("Add_Category");
            }
            return View("Add_Category");
        }

        [HttpGet("product/{productID}")]
        public IActionResult Product(int productID)
        {
            var product = dbContext.product.Include(p =>p.product_association).ThenInclude(c => c.category).FirstOrDefault(p =>p.productID == productID);
            HttpContext.Session.SetInt32("product_id",productID);
            ViewBag.product_details = product;
            ViewBag.category=dbContext.categories.ToList();
            return View();
            
        }

        [HttpPost("addCategoryToProduct")]
        public IActionResult AddCategoryToProduct(Association association)
        {
            int product_id = (int)HttpContext.Session.GetInt32("product_id");
            association.productID=product_id;
            dbContext.association.Add(association);
            dbContext.SaveChanges();
            return RedirectToAction("Product",new{productID=product_id});
        }
    }
}