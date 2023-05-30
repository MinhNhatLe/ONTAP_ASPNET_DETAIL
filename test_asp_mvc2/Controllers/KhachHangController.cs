using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_asp_mvc2.Models;

namespace test_asp_mvc2.Controllers
{
    public class KhachHangController : Controller
    {
        // Kết nối vào lấy danh sách dữ liệu bảng trong database
        QuanLyBanHang_TestEntities db = new QuanLyBanHang_TestEntities();
        public ActionResult DanhSach()
        {
            // lấy cái list trong bảng KhachHang ra
            // đặt tên là danhSachKhachHang
            // ToList là liệt kê ra danh sách
            List<KhachHang> danhSachKhachHang = db.KhachHangs.ToList();

            //đẩy cái danhSachKhachHang ra view
            return View(danhSachKhachHang);
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        // lấy cái bảng KhachHang trong database ra
        // đặt tên nó là model 
        public ActionResult ThemMoi(KhachHang model)
        {
            // Thêm mới bản ghi
            db.KhachHangs.Add(model);

            // Lưu lại thay đổi
            db.SaveChanges();

            // chuyển hướng sang trang Danh Sach
            return RedirectToAction("DanhSach");
        }


        public ActionResult CapNhat(int id)
        {
            // tìm đối tượng theo ID để lấy ra
            KhachHang model = db.KhachHangs.SingleOrDefault(m => m.ID == id);
            // dùng cách này để tìm đối tượng theo ID cũng được
            //KhachHang model1 = db.KhachHangs.Find(id);

            return View(model);
        }

        [HttpPost]
        // lấy cái bảng KhachHang trong database ra
        // đặt tên nó là model 
        public ActionResult CapNhat(KhachHang model, int id)
        {
            // tìm đối tượng id để lấy ra 
            KhachHang ten = db.KhachHangs.SingleOrDefault(m => m.ID == id);

            // gán giá trị
            ten.TenKhachHang = model.TenKhachHang;
            ten.SoDienThoai = model.SoDienThoai;
            ten.DiaChi = model.DiaChi;

            // Lưu lại thay đổi
            db.SaveChanges();

            // chuyển hướng sang trang Danh Sach
            return RedirectToAction("DanhSach");
        }


        public ActionResult Xoa(int id)
        {
            // tìm đối tượng id để lấy ra
            KhachHang ten = db.KhachHangs.SingleOrDefault(m => m.ID == id);

            // thực hiện chức năng remove để xóa cái đối tượng id vừa tìm
            db.KhachHangs.Remove(ten);

            // Lưu lại thay đổi
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
    }
}