using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using WebFinal.Models.BUS;

namespace WebFinal.Controllers
{
    public class DonViController : Controller
    {
		// GET: DonVi
		public ActionResult Login()
		{
			var model = ShopOnlineBus.Donvi(); // gọi hàm DanhSach() từ class ShopOnlineBus
			return View(model);
		}

		[HttpPost]
		public ActionResult Login(string tenDV, string maDV)
		{

			var db = new ShopConnectionDB();
			var user = db.SingleOrDefault<tb_Donvi>("SELECT * FROM tb_Donvi WHERE TenDV = @0 AND MaDV = @1", tenDV, maDV);
			if (user != null)
			{
				// đăng nhập thành công
				// lưu thông tin đăng nhập vào session hoặc cookie
				//lưu vào session
				Session["TenDV"] = tenDV;
				Session["MaDV"] = maDV;
				// chuyển hướng đến trang chính của ứng dụng
				return RedirectToAction("Index", "Home");
			}
			else
			{
				// đăng nhập thất bại
				// hiển thị thông báo lỗi hoặc redirect đến trang đăng nhập để người dùng nhập lại
				ModelState.AddModelError("", "Tên đơn vị hoặc mã đơn vị không đúng.");
				return View();
			}
		}

		public ActionResult Logout()
		{
			Session.Clear();
			return RedirectToAction("Index", "Home");
		}

	}
}