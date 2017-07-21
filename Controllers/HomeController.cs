using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tennis_market_plus_designs.Controllers
{
	public class HomeController : Controller
	{
		[DesignPage]
		public ActionResult Index()
		{
			return View();
		}

		[Route("Academies"), DesignPage]
		public ActionResult Academies()
		{
			return View("Academies");
		}

		[Route("Detail"), DesignPage]
		public ActionResult Detail()
		{
			return View("Detail");
		}

		[Route("Store"), DesignPage]
		public ActionResult Store()
		{
			return View("Store");
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}