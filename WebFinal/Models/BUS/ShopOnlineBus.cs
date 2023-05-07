using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFinal.Models.BUS
{
	public class ShopOnlineBus
	{
		public static IEnumerable<tb_Sanpham> DanhSach()
		{
			var db = new ShopConnectionDB();
			return db.Query<tb_Sanpham>("select * from tb_Sanpham");
		}

		public static IEnumerable<tb_Donvi> Donvi()
		{
			var db = new ShopConnectionDB();
			return db.Query<tb_Donvi>("select * from tb_Donvi");
		}
	}
}