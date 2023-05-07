using ShopConnection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinal.Class;

namespace WebFinal.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Addtocart(string masp, string tensp, string thumb, string dongia, int sl)
        {
			List<Product> cart = (List<Product>)Session["Cart"];
			if (cart == null)
			{
				cart = new List<Product>();
				Session["Cart"] = cart;
			}
			Product item = cart.FirstOrDefault(i => i.masp == masp);

			// Nếu sản phẩm chưa có trong giỏ hàng, thêm mới
			item = new Product
			{
				masp = masp,
				tensp = tensp,
				dongia = int.Parse(dongia),
				thumb = thumb,
				soluong = sl
			};
			cart.Add(item);
			
			

			return RedirectToAction("Cart");
		}

		public ActionResult Cart()
		{
			List<Product> cart = (List<Product>)Session["Cart"];
			int slGiohang = cart.Count;
			int total = 0;
			foreach (Product product in cart)
			{
				total += product.dongia * product.soluong;
			}
			ViewBag.total = total;
			ViewBag.SoluongSP = slGiohang;
			
			return View(cart);
		}


	}
}
