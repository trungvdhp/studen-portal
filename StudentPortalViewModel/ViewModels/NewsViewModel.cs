using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.ViewModels
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]
        public string Contents { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Ngày đăng")]
        public DateTime PostDate { get; set; }

        [Display(Name = "Lần sửa cuối")]
        public DateTime LastEditDate { get; set; }

        [Display(Name = "Lượt xem")]
        public int TotalView { get; set; }

        [Display(Name = "Đường dẫn ảnh")]
        public string ImageUrl { get; set; }

        [Display(Name = "Người tạo")]
        public string User { get; set; }

        [Display(Name = "Người sửa cuối")]
        public string LastEditUser { get; set; }
    }
}