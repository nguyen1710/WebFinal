using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinal.Models.BUS;
namespace WebFinal.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var model = ShopOnlineBus.DanhSach(); // gọi hàm DanhSach() từ class ShopOnlineBus
			return View(model);
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