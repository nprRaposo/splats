using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Splats.Data.DAL;
using Splats.Data.Entities;
using Splats.Services;

namespace Splats.Web.Controllers
{
    public class SeriesController : Controller
    {
        public ActionResult Index()
        {
			return View(SeriesService.Get());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var serie = SeriesService.GetBy(id.Value);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Seasons,Description")] Serie serie)
        {
			SeriesService.Insert(serie);
			return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var serie = SeriesService.GetBy(id.Value);

            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Seasons,Description")] Serie serie)
        {
            if (ModelState.IsValid)
            {
				SeriesService.Update(serie);
                return RedirectToAction("Index");
            }
            return View(serie);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

			var serie = SeriesService.GetBy(id.Value);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			SeriesService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
