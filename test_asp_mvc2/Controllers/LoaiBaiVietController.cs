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
            if (string.IsNullOrEmpty(model.TenLoai) == true)
            {
                ModelState.AddModelError("", "Thieu thong tin ten loai bai viet");
                return View(model);
            }

            try
            {
                db.LoaiBaiViets.Add(model);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
            
        }

        public ActionResult CapNhatLoaiBaiViet(int id)
        {
            var tenLoai = db.LoaiBaiViets.Find(id);
            return View(tenLoai);
        }
        [HttpPost]
        public ActionResult CapNhatLoaiBaiViet(LoaiBaiViet model,int id)
        {
            if (string.IsNullOrEmpty(model.TenLoai) == true)
            {
                ModelState.AddModelError("", "Thieu thong tin ten loai bai viet");
                return View(model);
            }

                var tenLoai = db.LoaiBaiViets.Find(id);
            try
            {

                tenLoai.TenLoai = model.TenLoai;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
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