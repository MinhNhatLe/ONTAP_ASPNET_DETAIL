using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_asp_mvc2.Models;

namespace test_asp_mvc2.Controllers
{
    public class LoaiBaiVietController : Controller
    {
        QuanLyBanHang_TestEntities db = new QuanLyBanHang_TestEntities();
        // GET: LoaiBaiViet
        public ActionResult DanhSach()
        {
            List<LoaiBaiViet> danhSachLoaiBaiViet = db.LoaiBaiViets.ToList();
            return View(danhSachLoaiBaiViet);
        }

        public ActionResult ThemLoaiBaiViet()
        {
            return View();

        }
        [HttpPost]
        public ActionResult ThemLoaiBaiViet(LoaiBaiViet model)
        {
            db.LoaiBaiViets.Add(model);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

        public ActionResult CapNhatLoaiBaiViet(int id)
        {
            var tenLoai = db.LoaiBaiViets.Find(id);
            return View(tenLoai);
        }
        [HttpPost]
        public ActionResult CapNhatLoaiBaiViet(LoaiBaiViet model,int id)
        {
            var tenLoai = db.LoaiBaiViets.Find(id);

            tenLoai.TenLoai = model.TenLoai;
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

        public ActionResult XoaLoaibaiViet(int id)
        {
            var tenLoai = db.LoaiBaiViets.Find(id);
            db.LoaiBaiViets.Remove(tenLoai);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
    }
}