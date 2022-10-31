using ECommerce.BusinessLogic;
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
    public class ItemController : Controller
    {
        ItemBAL itemContext=new ItemBAL();


            // GET: Item
            [HttpGet]
            public ActionResult Index()
            {
                List<Item> list = itemContext.Get();

                return View(list);
            }
            public ActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Create(Item item)
            {
                try
                {
                    if (ModelState.IsValid == true)
                    {

                        int check = itemContext.Add(item);
                        if (check >= 0)
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

                var row = itemContext.Get().Find(model => model.Id == id);
                return View(row);
            }

            [HttpPost]
            public ActionResult Edit(int id, Item item)
            {
                try
                {
                    if (ModelState.IsValid == true)
                    {

                        int check = itemContext.Update(item);
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

                var row = itemContext.Get().Find(model => model.Id == id);
                return View(row);
            }

            [HttpPost]
            public ActionResult Delete(int id, Item item)
            {
                try
                {


                    int check = itemContext.Delete(id);
                    if (check >= 0)
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

                var row = itemContext.Get().Find(model => model.Id == id);
                return View(row);
            }
        }
}