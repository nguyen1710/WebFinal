using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinal.Class;

namespace WebFinal.Controllers
{
    public class ThanhtoanController : Controller
    {
        // GET: Thanhtoan
        public ActionResult Index()
        {
            return View();
        }


		public ActionResult Payment()
		{
			var db = new ShopConnectionDB();
			Random random = new Random();
			int randomNumber = random.Next(100, 1000);
			List<Product> cart = (List<Product>)Session["Cart"];
			string ngayxuat = DateTime.Today.ToString("yyyy/MM/dd");
			string formattedDateString = DateTime.Today.ToString("yyyy/MM/dd").Replace("/", "");
			int tongsoluong = 0;
			int tongdongia = 0;

			foreach (var item in cart)
			{
				var sql = "insert into tb_Chungtuchitiet VALUES(N'" + formattedDateString + "/XMH/" + randomNumber.ToString() + "', N'XMH" + formattedDateString + randomNumber.ToString() + "', N'" + item.masp + "', " + item.soluong + ", " + item.dongia * item.soluong + ", '' ) ";
				db.Execute(sql);
				tongdongia += item.dongia * item.soluong;
				tongsoluong += item.soluong;
			}
			var queryChungtu = "insert into tb_Chungtu VALUES(N'CT" + formattedDateString + "/XMH/" + randomNumber.ToString() + "', N'XMH', N'', '',N'XMH" + formattedDateString + randomNumber.ToString() + "', '" + ngayxuat + "','', N'" + Session["MaDV"] + "', '','','', " + tongsoluong + ", " + tongdongia + ") ";
			db.Execute(queryChungtu);

			return View();
		}
	}
}