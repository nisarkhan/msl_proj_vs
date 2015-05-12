using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSL.Controllers
{
    public class MSLDataEntryController : Controller
    {
        // GET: MSLDataEntry
        public ActionResult Index()
        {
            return View();
        }

        // GET: MSLDataEntry/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MSLDataEntry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MSLDataEntry/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MSLDataEntry/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MSLDataEntry/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MSLDataEntry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MSLDataEntry/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
