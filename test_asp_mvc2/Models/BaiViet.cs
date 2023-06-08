//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace test_asp_mvc2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BaiViet
    {
        public int ID { get; set; }
        [Required(ErrorMessage = " nhap ten bai viet ")]
        [MinLength(5, ErrorMessage = " khong duoc it hon 5 ")]
        [MaxLength(20, ErrorMessage = "Nhap nhieu nhat la 20 ki tu")]
        public string TenBaiViet { get; set; }
        [Required(ErrorMessage = " nhap mo ta ")]
        [MinLength(5, ErrorMessage = " khong duoc it hon 5 ")]
        [MaxLength(20, ErrorMessage = "Nhap nhieu nhat la 20 ki tu")]
        public string MoTa { get; set; }
        public Nullable<System.DateTime> NgayViet { get; set; }
        public string NguoiViet { get; set; }
        //[DisplayName("Thong bao loi : ")]
        [Required(ErrorMessage = " nhap noi dung ")]
        [MinLength(5, ErrorMessage = " khong duoc it hon 5 ")]
        [MaxLength(20, ErrorMessage = "Nhap nhieu nhat la 20 ki tu")]

        public string NoiDung { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<bool> HienThi { get; set; }
        public Nullable<int> ThuTu { get; set; }
        public Nullable<int> idBaiViet { get; set; }
    
        public virtual LoaiBaiViet LoaiBaiViet { get; set; }
    }
}
