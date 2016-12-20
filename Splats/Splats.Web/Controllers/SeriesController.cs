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
using Splats.Services.Generic;

namespace Splats.Web.Controllers
{
    public class SeriesController : Controller
    {
		#region Properties
		private readonly IService<Serie> _seriesService; 
		#endregion

		public SeriesController(IService<Serie> seriesService)
		{
			this._seriesService = seriesService;
		}

		public ActionResult Index()
        {
			return View(this._seriesService.Get());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var serie = this._seriesService.GetBy(id.Value);
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
			//SeriesService.Insert(serie);
			serie.DirectorId = 1;
			this._seriesService.Insert(serie);
			return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var serie = this._seriesService.GetBy(id.Value);

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
				this._seriesService.Update(serie);
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

			var serie = this._seriesService.GetBy(id.Value);
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
			this._seriesService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
