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
using Splats.Web.Controls;

namespace Splats.Web.Controllers
{
	public class SeriesController : Controller
	{
		#region Properties
		private readonly IService<Serie> _seriesService;
		private readonly IService<Director> _directorsService;
		#endregion

		public SeriesController(IService<Serie> seriesService, IService<Director> directorsService)
		{
			this._seriesService = seriesService;
			this._directorsService = directorsService;
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
			return PartialView(serie);
		}

		public ActionResult Create()
		{
			ViewBag.Directors = new SelectList(this._directorsService.Get(), "Id", "FullName");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name,Seasons,Description, DirectorId, ImageUrl")] Serie serie)
		{
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

			ViewBag.Directors = new SelectList(this._directorsService.Get(), "Id", "FullName", serie.DirectorId);
			return PartialView(serie);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public JsonResult Edit([Bind(Include = "Id,Name,Seasons,Description, DirectorId, ImageUrl")] Serie serie)
		{
			this._seriesService.Update(serie);
			return Json(new { Result = true, SerieId = serie.Id }, JsonRequestBehavior.AllowGet);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			this._seriesService.Delete(id);
			return Json(new { Result = true, SerieId = id}, JsonRequestBehavior.AllowGet);
		}

		public ActionResult ReloadSerie(int serieId)
		{
			var serie = this._seriesService.GetBy(serieId);
			var model = new SerieListItemModel
			{
				Id = serie.Id,
				Description = serie.Description,
				ImageUrl = serie.ImageUrl,
				Title = serie.Name
			};

			return PartialView("~/Views/Controls/SerieListItem.cshtml", model);
		}

	}
}
