using Splats.Data.Entities;
using Splats.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Splats.Web.Areas.Directors.Controllers
{
    public class DirectorController : Controller
    {

		#region Properties
		private readonly IService<Director> _directorsService;
		#endregion

		public DirectorController(IService<Director> directorsService)
		{
			this._directorsService = directorsService;
		}

		public ActionResult Index()
        {
			return View(this._directorsService.Get());
		}

		[Route("/api/directors")]
		public JsonResult DirectorsApi()
		{
			return Json(new { Result = true, Directors = this._directorsService.Get()}, JsonRequestBehavior.AllowGet);
		}

        // GET: Director/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Director/Create
        [HttpPost]
		[ValidateAntiForgeryToken]
        public ActionResult Create(Director director)
        {
            try
            {
				this._directorsService.Insert(director);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(this._directorsService.GetBy(id));
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Director director)
        {
            try
            {
				this._directorsService.Update(director);
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
