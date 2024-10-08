﻿using ECommerce.BusinessLogic;
using ECommerce.BusinessObjects;
using ECommerce.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceApp.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        CategoryBAL categoryContext=new CategoryBAL();
        

        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            List<Category> list = categoryContext.Get();
             
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    
                    int check = categoryContext.Add(category);
                    if (check>=0)
                    {
                        TempData["InsertMessage"] = " Data has been inserted successully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }

            catch (Exception)
            {
                return View();
            }

        }
        public ActionResult Edit(int id)
        {
          
            var row = categoryContext.Get().Find(model => model.Id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(int id, Category cat)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    
                    int check = categoryContext.Update(cat);
                    if (check >= 0)
                    {
                        TempData["UpdateMessage"] = " Data has been Updated successully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }

            catch (Exception)
            {
                return View();
            }

        }

        public ActionResult Delete(int id)
        {
            
            var row = categoryContext.Get().Find(model => model.Id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int id, Category cat)
        {
            try
            {

                
                int check = categoryContext.Delete(id);
                if (check>=0)
                {
                    TempData["DeleteMessage"] = " Data has been Delete successully";

                    return RedirectToAction("Index");
                }

                return View();
            }

            catch (Exception)
            {
                return View();
            }

        }
        public ActionResult Details(int id)
        {
            
            var row = categoryContext.Get().Find(model => model.Id == id);
            return View(row);
        }
        [HandleError]
        public ActionResult Items(Category ct)
        {
            try
            {
                ItemBAL cat = new ItemBAL();
                List<Item> row = cat.GetByCategory(ct.Name);

                return View(row);
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "Category", "Item"));
            }

        }
    }
}