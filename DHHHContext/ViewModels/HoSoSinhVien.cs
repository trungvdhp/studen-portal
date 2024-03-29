﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.ViewModels
{
    public class HoSoSinhVien
    {
        public int ID_sv { get; set; }

        [Display(Name = "Ảnh")]
        public byte[] Anh { get; set; }

        [Display(Name = "Mã SV")]
        public string Ma_sv { get; set; }

        [Display(Name = "Họ tên")]
        public string Ho_ten { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required]
        public Nullable<System.DateTime> Ngay_sinh { get; set; }

        [Display(Name = "ID Giới tính")]
        [ForeignKey("STU_GioiTinh")]
        public Nullable<int> ID_gioi_tinh { get; set; }

        [Display(Name = "ID Dân tộc")]
        [ForeignKey("STU_DanToc")]
        public Nullable<int> ID_dan_toc { get; set; }

        [Display(Name = "ID Quốc tịch")]
        [Required]
        public Nullable<int> ID_quoc_tich { get; set; }

        [Display(Name = "Tôn giáo")]
        public string Ton_giao { get; set; }

        [Display(Name = "ID Thành phần xuất thân")]
        [ForeignKey("STU_ThanhPhanXuatThan")]
        public Nullable<int> ID_thanh_phan_xuat_than { get; set; }

        [Display(Name = "Ngày vào Đoàn")]
        public Nullable<System.DateTime> Ngay_vao_doan { get; set; }

        [Display(Name = "Ngày vào Đảng")]
        public Nullable<System.DateTime> Ngay_vao_dang { get; set; }

        [Display(Name = "Quê quán")]
        public string Que_quan { get; set; }

        [Display(Name = "ID Tỉnh ns")]
        public string ID_tinh_ns { get; set; }

        [Display(Name = "Địa chỉ TT")]
        public string Dia_chi_tt { get; set; }

        [Display(Name = "Xã phường TT")]
        public string Xa_phuong_tt { get; set; }

        [Display(Name = "ID Huyện TT")]
        public string ID_huyen_tt { get; set; }

        [Display(Name = "ID Tỉnh TT")]
        public string ID_tinh_tt { get; set; }

        [Display(Name = "ID Đối tượng TC")]
        public Nullable<int> ID_doi_tuong_TC { get; set; }

        [Display(Name = "ID Đối tượng TS")]
        public Nullable<int> ID_doi_tuong_TS { get; set; }

        [Display(Name = "Điện thoại NR")]
        public string Dien_thoai_NR { get; set; }

        [Display(Name = "ID Nhóm đối tượng")]
        [ForeignKey("STU_NhomDoiTuong")]
        public Nullable<int> ID_nhom_doi_tuong { get; set; }

        [Display(Name = "Địa chỉ báo tin")]
        [Required]
        public string Dia_chi_bao_tin { get; set; }

        [Display(Name = "ID Khu vực TS")]
        public Nullable<int> ID_khu_vuc_TS { get; set; }

        [Display(Name = "Đối tượng dự thi")]
        public string Doi_tuong_du_thi { get; set; }

        [Display(Name = "Điểm 1")]
        public Nullable<float> Diem1 { get; set; }

        [Display(Name = "Điểm 2")]
        public Nullable<float> Diem2 { get; set; }

        [Display(Name = "Điểm 3")]
        public Nullable<float> Diem3 { get; set; }

        [Display(Name = "Điểm 4")]
        public Nullable<float> Diem4 { get; set; }

        [Display(Name = "Tổng điểm")]
        public Nullable<float> Tong_diem { get; set; }

        [Display(Name = "SBD")]
        public string SBD { get; set; }

        [Display(Name = "Ngành tuyển sinh")]
        public string Nganh_tuyen_sinh { get; set; }

        [Display(Name = "Khối thi")]
        public string Khoi_thi { get; set; }

        [Display(Name = "Xếp loại HT")]
        public string Xep_loai_hoc_tap { get; set; }

        [Display(Name = "Xếp loại HK")]
        public string Xep_loai_hanh_kiem { get; set; }

        [Display(Name = "Xếp loại TN")]
        public string Xep_loai_tot_nghiep { get; set; }

        [Display(Name = "Năm tốt nghiệp")]
        public string Nam_tot_nghiep { get; set; }

        [Display(Name = "Điểm thưởng")]
        public Nullable<float> Diem_thuong { get; set; }

        [Display(Name = "Lý do thưởng điểm")]
        public string Ly_do_thuong_diem { get; set; }

        [Display(Name = "Khen thưởng kỷ luật")]
        public string Khen_thuong_ky_luat { get; set; }

        [Display(Name = "Quá trình HT_LD")]
        public string Qua_trinh_HT_LD { get; set; }


        [Display(Name = "Họ tên Cha")]
        public string Ho_ten_cha { get; set; }

        [Display(Name = "ID Quốc tịch Cha")]
        public Nullable<int> ID_quoc_tich_cha { get; set; }

        [Display(Name = "ID Dân tộc Cha")]
        public Nullable<int> ID_dan_toc_cha { get; set; }

        [Display(Name = "Tôn giáo Cha")]
        public string Ton_giao_cha { get; set; }

        [Display(Name = "Hộ khẩu TT Cha")]
        public string Ho_khau_TT_cha { get; set; }

        [Display(Name = "Hoạt động XH_CT Cha")]
        public string Hoat_dong_XH_CT_cha { get; set; }

        [Display(Name = "Họ tên Mẹ")]
        public string Ho_ten_me { get; set; }

        [Display(Name = "ID Quốc tịch Mẹ")]
        public Nullable<int> ID_quoc_tich_me { get; set; }

        [Display(Name = "ID Dân tộc Mẹ")]
        public Nullable<int> ID_dan_toc_me { get; set; }

        [Display(Name = "Tôn giáo Mẹ")]
        public string Ton_giao_me { get; set; }

        [Display(Name = "Hộ khẩu TT Mẹ")]
        public string Ho_khau_TT_me { get; set; }

        [Display(Name = "Hoạt động XH_CT Mẹ")]
        public string Hoat_dong_XH_CT_me { get; set; }

        [Display(Name = "Họ tên vợ chồng")]
        public string Ho_ten_vo_chong { get; set; }

        [Display(Name = "ID Quốc tich vợ chồng")]
        public Nullable<int> ID_quoc_tich_vo_chong { get; set; }

        [Display(Name = "ID Dân tộc vợ chồng")]
        public Nullable<int> ID_dan_toc_vo_chong { get; set; }

        [Display(Name = "Tôn giáo vợ chồng")]
        public string Ton_giao_vo_chong { get; set; }

        [Display(Name = "Hộ khẩu TT vợ chồng")]
        public string Ho_khau_TT_vo_chong { get; set; }

        [Display(Name = "Hoạt động XH_CT vợ chồng")]
        public string Hoat_dong_XH_CT_vo_chong { get; set; }

        [Display(Name = "Họ tên nghề nghiệp anh em")]
        public string Ho_ten_nghe_nghiep_anh_em { get; set; }

        [Display(Name = "Đăng ký học")]
        public Nullable<bool> Dang_ky_hoc { get; set; }

        [Display(Name = "Họ tên Order")]
        public string Hoten_Order { get; set; }

        [Display(Name = "Chuyên ngành đăng ký")]
        public string Chuyen_nganh_dang_ky { get; set; }

        [Display(Name = "Lớp")]
        public string Lop { get; set; }

        [Display(Name = "Ngoại ngữ")]
        public string Ngoai_ngu { get; set; }

        [Display(Name = "UserID")]
        public Nullable<int> UserID { get; set; }

        [Display(Name = "Ngày nhập học")]
        public Nullable<System.DateTime> Ngay_nhap_hoc { get; set; }

        [Display(Name = "UserName tiếp nhận")]
        public string UserName_tiep_nhan { get; set; }

        [Display(Name = "UserID tiếp nhận")]
        public Nullable<int> UserID_tiep_nhan { get; set; }

        [Display(Name = "CMND")]
        public string CMND { get; set; }

        [Display(Name = "Ngày cấp")]
        public Nullable<System.DateTime> Ngay_cap { get; set; }

        [Display(Name = "Nơi cấp")]
        public string Noi_cap { get; set; }

        [Display(Name = "Điện thoại cá nhân")]
        [Required]
        public string Dienthoai_canhan { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Nơi ở hiện tại")]
        public string NoiO_hiennay { get; set; }

        [Display(Name = "Năm sinh Cha")]
        public string Namsinh_cha { get; set; }

        [Display(Name = "Năm sinh Mẹ")]
        public string Namsinh_me { get; set; }

        [Display(Name = "IDCard")]
        public string IDCard { get; set; }

        [Display(Name = "Năm nhâp học")]
        public string Nam_nhap_hoc { get; set; }

        [Display(Name = "Số tài khoản")]
        public string So_tai_khoan { get; set; }

        [Display(Name = "ID Xếp hạng học lực")]
        public Nullable<int> ID_xep_hang_hoc_luc { get; set; }

        [Display(Name = "Đã nhập trường")]
        public bool Da_nhap_truong { get; set; }

        [Display(Name = "SV ngoại tỉnh")]
        public bool SV_ngoai_tinh { get; set; }

        [Display(Name = "Mã Hồ sơ")]
        public string Ma_ho_so { get; set; }

        [Display(Name = "Ngành TS")]
        public string NGANHTS { get; set; }

        [Display(Name = "CNGANHTT")]
        public string CNGANHTT { get; set; }

        [Display(Name = "TTNganh")]
        public Nullable<int> TTNganh { get; set; }

        [Display(Name = "Trường THPT")]
        public string TruongTHPT { get; set; }

        [Display(Name = "Ban TS")]
        public string BanTS { get; set; }

        [Display(Name = "Đơn vị DKDT")]
        public string DonViDKDT { get; set; }

        [Display(Name = "Phiếu DKDT")]
        public string PhieuDKDL { get; set; }

        [Display(Name = "Lớp 10")]
        public string LOP10 { get; set; }

        [Display(Name = "Lớp 11")]
        public string LOP11 { get; set; }

        [Display(Name = "Lớp 12")]
        public string LOP12 { get; set; }

        [Display(Name = "Hệ nhập học")]
        public string He_nhap_hoc { get; set; }

        [Display(Name = "Trạng thái học")]
        public Nullable<int> Trang_thai_hoc { get; set; }
        
    }
}
