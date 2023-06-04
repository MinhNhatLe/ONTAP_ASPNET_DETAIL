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
            return View(new BaiViet());
        }
        [HttpPost]
        [ValidateInput(false)]
        // Các bước sử dụng CKEditor
        //1: tải bộ plugin vào project
        //2: kéo file js vào layout
        //3: thay đổi input bằng textarea và đặt id cho input đó
        //4: viết lệnh js cho textarea
        //5: lưu dữ liệu: - tắt hàm kiểm tra HTMl cho action Lưu dữ liệu [ValidateInput(false)]
        public ActionResult ThemBaiViet(BaiViet model)
        {
            if (string.IsNullOrEmpty(model.TenBaiViet) == true)
            {
                ModelState.AddModelError("", "Thieu thong tin ten bai viet");
                return View(model);
            }
            try
            {
                db.BaiViets.Add(model);
                db.SaveChanges();
                return RedirectToAction("DanhSachBaiViet");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }            
        }

        public ActionResult CapNhatBaiViet(int id)
        {
            var tenBaiViet = db.BaiViets.Find(id);
            return View(tenBaiViet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhatBaiViet(BaiViet model, int id)
        {
            if (string.IsNullOrEmpty(model.TenBaiViet) == true)
            {
                ModelState.AddModelError("", "Thieu thong tin ten bai viet");
                return View(model);
            }
            var tenBaiViet = db.BaiViets.Find(id);
            try
            {
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
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