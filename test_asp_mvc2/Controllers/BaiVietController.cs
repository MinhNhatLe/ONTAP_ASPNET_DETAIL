using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_asp_mvc2.Models;

namespace test_asp_mvc2.Controllers
{
    public class BaiVietController : Controller
    {
        QuanLyBanHang_TestEntities db = new QuanLyBanHang_TestEntities();
        // GET: BaiViet
        public ActionResult DanhSachBaiViet()
        {
            List<BaiViet> danhSachBaiViet = db.BaiViets.ToList();
            return View(danhSachBaiViet);
        }

        public ActionResult ThemBaiViet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemBaiViet(BaiViet model)
        {
            db.BaiViets.Add(model);
            db.SaveChanges();
            return RedirectToAction("DanhSachBaiViet");
        }

        public ActionResult CapNhatBaiViet(int id)
        {
            var tenBaiViet = db.BaiViets.Find(id);
            return View(tenBaiViet);
        }
        [HttpPost]
        public ActionResult CapNhatBaiViet(BaiViet model, int id)
        {
            var tenBaiViet = db.BaiViets.Find(id);

            tenBaiViet.TenBaiViet = model.TenBaiViet;
            tenBaiViet.MoTa = model.MoTa;
            tenBaiViet.NgayViet = model.NgayViet;
            tenBaiViet.NguoiViet = model.NguoiViet;
            tenBaiViet.NoiDung = model.NoiDung;
            tenBaiViet.HinhAnh = model.HinhAnh;
            tenBaiViet.HienThi = model.HienThi;
            tenBaiViet.ThuTu = model.ThuTu;
            tenBaiViet.idBaiViet = model.idBaiViet;

            db.SaveChanges();
            return RedirectToAction("DanhSachBaiViet");
        }

        public ActionResult XoaBaiViet(int id)
        {
            var tenBaiViet = db.BaiViets.Find(id);
            db.BaiViets.Remove(tenBaiViet);
            db.SaveChanges();
            return RedirectToAction("DanhSachBaiViet");

        }
    }
}