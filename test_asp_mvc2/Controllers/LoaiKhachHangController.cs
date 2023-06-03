using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_asp_mvc2.Models;

namespace test_asp_mvc2.Controllers
{
    public class LoaiKhachHangController : Controller
    {
        QuanLyBanHang_TestEntities db = new QuanLyBanHang_TestEntities();
        // GET: LoaiKhachHang
        public ActionResult DanhSachLoaiKhachHang()
        {
            List<LoaiKhachHang> danhSachLoaiKhachHang = db.LoaiKhachHangs.ToList();
            return View(danhSachLoaiKhachHang);
        }


        public ActionResult ThemLoaiKhachHang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemLoaiKhachHang(LoaiKhachHang model)
        {
            db.LoaiKhachHangs.Add(model);
            db.SaveChanges();
            return RedirectToAction("DanhSachLoaiKhachHang");
        }

        public ActionResult CapNhatLoaiKhachHang(int id)
        {
            
            var tenLoai = db.LoaiKhachHangs.Find(id);
            return View(tenLoai);
        }
        [HttpPost]
        public ActionResult CapNhatLoaiKhachHang(LoaiKhachHang model, int id)
        {
            var tenLoai = db.LoaiKhachHangs.Find(id);

            tenLoai.TenPhanLoai = model.TenPhanLoai;
            db.SaveChanges();
            return RedirectToAction("DanhSachLoaiKhachHang");
        }

        public ActionResult Xoa(int id)
        {
            var tenLoai = db.LoaiKhachHangs.Find(id);
            db.LoaiKhachHangs.Remove(tenLoai);

            db.SaveChanges();
            return RedirectToAction("DanhSachLoaiKhachHang");
        }
    }
}