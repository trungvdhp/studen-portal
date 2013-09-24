﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using StudentPortal.Models;

namespace StudentPortal
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Infrastructure;

	public partial class DHHHContext : DbContext
	{
		public DHHHContext()
			: base("name=DHHHConnection")
		{
		}

		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{
		//    throw new UnintentionalCodeFirstException();
		//}


		public DbSet<ACC_BienLaiThu> ACC_BienLaiThu { get; set; }
		public DbSet<ACC_BienLaiThu_ThiLai> ACC_BienLaiThu_ThiLai { get; set; }
		public DbSet<ACC_BienLaiThuChiTiet> ACC_BienLaiThuChiTiet { get; set; }
		public DbSet<ACC_BienLaiThuChiTiet_ThiLai> ACC_BienLaiThuChiTiet_ThiLai { get; set; }
		//public DbSet<ACC_BienLaiThuChiTietCopy> ACC_BienLaiThuChiTietCopy { get; set; }
		//public DbSet<ACC_BienLaiThuCopy> ACC_BienLaiThuCopy { get; set; }
		//public DbSet<ACC_BienLaiThuHocLai> ACC_BienLaiThuHocLai { get; set; }
		//public DbSet<ACC_CHUYENKHOAN> ACC_CHUYENKHOAN { get; set; }
		//public DbSet<ACC_DanhSachHocBong> ACC_DanhSachHocBong { get; set; }
		//public DbSet<ACC_DanhSachMienGiamHocPhi> ACC_DanhSachMienGiamHocPhi { get; set; }
		//public DbSet<ACC_DanhSachNoHocPhi> ACC_DanhSachNoHocPhi { get; set; }
		//public DbSet<ACC_DanhSachThuPhiHocBu> ACC_DanhSachThuPhiHocBu { get; set; }
		//public DbSet<ACC_DinhMucGiaoVien> ACC_DinhMucGiaoVien { get; set; }
		//public DbSet<ACC_HeSoHocPhi> ACC_HeSoHocPhi { get; set; }
		//public DbSet<ACC_HoatDongKhoaHocCongNghe> ACC_HoatDongKhoaHocCongNghe { get; set; }
		//public DbSet<ACC_LoaiCongViec> ACC_LoaiCongViec { get; set; }
		//public DbSet<ACC_LoaiMienGiamNienKhoa> ACC_LoaiMienGiamNienKhoa { get; set; }
		//public DbSet<ACC_LoaiMienGiamTinChi> ACC_LoaiMienGiamTinChi { get; set; }
		//public DbSet<ACC_LoaiQuy> ACC_LoaiQuy { get; set; }
		public DbSet<ACC_LoaiThuChi> ACC_LoaiThuChi { get; set; }
		//public DbSet<ACC_MucHocPhiTinChi> ACC_MucHocPhiTinChi { get; set; }
		//public DbSet<ACC_MucThuKhacSinhVien> ACC_MucThuKhacSinhVien { get; set; }
		//public DbSet<ACC_MucThuKhacSinhVienCopy> ACC_MucThuKhacSinhVienCopy { get; set; }
		//public DbSet<ACC_ThiLai> ACC_ThiLai { get; set; }
		//public DbSet<MARK_ChungChiSinhVien_TC> MARK_ChungChiSinhVien_TC { get; set; }
		//public DbSet<Mark_DanhSachChuaTotNghiep> Mark_DanhSachChuaTotNghiep { get; set; }
		//public DbSet<Mark_DanhSachHoctiep> Mark_DanhSachHoctiep { get; set; }
		//public DbSet<Mark_DanhSachLuanVan> Mark_DanhSachLuanVan { get; set; }
		//public DbSet<Mark_DanhSachNganh2> Mark_DanhSachNganh2 { get; set; }
		//public DbSet<Mark_DanhSachNgunghoc> Mark_DanhSachNgunghoc { get; set; }
		//public DbSet<Mark_DanhSachNoTotNghiep> Mark_DanhSachNoTotNghiep { get; set; }
		//public DbSet<Mark_DanhSachThiTotNghiep> Mark_DanhSachThiTotNghiep { get; set; }
		//public DbSet<Mark_DanhSachThuctap> Mark_DanhSachThuctap { get; set; }
		//public DbSet<MARK_DanhSachTotNghiep> MARK_DanhSachTotNghiep { get; set; }
		//public DbSet<MARK_Diem> MARK_Diem { get; set; }
		public DbSet<MARK_Diem_TC> MARK_Diem_TC { get; set; }
		//public DbSet<MARK_DiemDanh> MARK_DiemDanh { get; set; }
		//public DbSet<MARK_DiemDanh_TC> MARK_DiemDanh_TC { get; set; }
		//public DbSet<MARK_DiemKyHieu> MARK_DiemKyHieu { get; set; }
		//public DbSet<MARK_DiemKyHieu_TC> MARK_DiemKyHieu_TC { get; set; }
		//public DbSet<MARK_DiemQuyDoi> MARK_DiemQuyDoi { get; set; }
		//public DbSet<MARK_DiemQuyDoi_TC> MARK_DiemQuyDoi_TC { get; set; }
		//public DbSet<MARK_DiemRenLuyen> MARK_DiemRenLuyen { get; set; }
		//public DbSet<MARK_DiemRenLuyenTinChi_TC> MARK_DiemRenLuyenTinChi_TC { get; set; }
		//public DbSet<MARK_DiemThanhPhan> MARK_DiemThanhPhan { get; set; }
		public DbSet<MARK_DiemThanhPhan_TC> MARK_DiemThanhPhan_TC { get; set; }
		//public DbSet<MARK_DiemThi> MARK_DiemThi { get; set; }
		public DbSet<MARK_DiemThi_TC> MARK_DiemThi_TC { get; set; }
		//public DbSet<MARK_HocLai> MARK_HocLai { get; set; }
		//public DbSet<MARK_LoaiChungChi> MARK_LoaiChungChi { get; set; }
		//public DbSet<MARK_LoaiChungChi_TC> MARK_LoaiChungChi_TC { get; set; }
		//public DbSet<MARK_LoaiChungChiDanhSachMon> MARK_LoaiChungChiDanhSachMon { get; set; }
		//public DbSet<MARK_LoaiChungChiDanhSachMon_TC> MARK_LoaiChungChiDanhSachMon_TC { get; set; }
		public DbSet<MARK_MonHoc> MARK_MonHoc { get; set; }
		//public DbSet<MARK_MucThiLai_TC> MARK_MucThiLai_TC { get; set; }
		public DbSet<MARK_NhanXetKy_TC> MARK_NhanXetKy_TC { get; set; }
		public DbSet<MARK_NhanXetNam_TC> MARK_NhanXetNam_TC { get; set; }
		//public DbSet<MARK_NoKhacKhiXetTotNghiep> MARK_NoKhacKhiXetTotNghiep { get; set; }
		//public DbSet<MARK_QuyetDinhThoiHoc> MARK_QuyetDinhThoiHoc { get; set; }
		//public DbSet<MARK_QuyetDinhThoiHocChiTiet> MARK_QuyetDinhThoiHocChiTiet { get; set; }
		//public DbSet<MARK_ThamSoQuyChe> MARK_ThamSoQuyChe { get; set; }
		//public DbSet<MARK_ThanhPhanMon> MARK_ThanhPhanMon { get; set; }
		public DbSet<MARK_ThanhPhanMon_TC> MARK_ThanhPhanMon_TC { get; set; }
		//public DbSet<MARK_ThiTotNghiep_DangKy> MARK_ThiTotNghiep_DangKy { get; set; }
		//public DbSet<MARK_TochucThi> MARK_TochucThi { get; set; }
		//public DbSet<MARK_TochucThi_TC> MARK_TochucThi_TC { get; set; }
		//public DbSet<MARK_TochucThiChiTiet> MARK_TochucThiChiTiet { get; set; }
		//public DbSet<MARK_TochucThiChiTiet_TC> MARK_TochucThiChiTiet_TC { get; set; }
		//public DbSet<MARK_ToChucThiDangKyCaiThienDiem_TC> MARK_ToChucThiDangKyCaiThienDiem_TC { get; set; }
		//public DbSet<MARK_ToChucThiLapTuiThi_TC> MARK_ToChucThiLapTuiThi_TC { get; set; }
		//public DbSet<MARK_ToChucThiPhong> MARK_ToChucThiPhong { get; set; }
		//public DbSet<MARK_ToChucThiPhong_TC> MARK_ToChucThiPhong_TC { get; set; }
		//public DbSet<MARK_ToChucThiPhucKhao_TC> MARK_ToChucThiPhucKhao_TC { get; set; }
		//public DbSet<MARK_ToChucThiQuyDinhDangKy_TC> MARK_ToChucThiQuyDinhDangKy_TC { get; set; }
		//public DbSet<MARK_TotNghiep_DangKy> MARK_TotNghiep_DangKy { get; set; }
		//public DbSet<MARK_TrangThaiHoc> MARK_TrangThaiHoc { get; set; }
		//public DbSet<MARK_TrangThaiHoc_TC> MARK_TrangThaiHoc_TC { get; set; }
		//public DbSet<MARK_TrangThaiHoctiep> MARK_TrangThaiHoctiep { get; set; }
		//public DbSet<MARK_TrangThaiHoctiep_TC> MARK_TrangThaiHoctiep_TC { get; set; }
		//public DbSet<MARK_XepHangHocLuc> MARK_XepHangHocLuc { get; set; }
		//public DbSet<MARK_XepHangHocLuc_TC> MARK_XepHangHocLuc_TC { get; set; }
		//public DbSet<MARK_XepHangNamDaoTao> MARK_XepHangNamDaoTao { get; set; }
		//public DbSet<MARK_XepHangNamDaoTao_TC> MARK_XepHangNamDaoTao_TC { get; set; }
		//public DbSet<MARK_XepHangTotNghiep> MARK_XepHangTotNghiep { get; set; }
		//public DbSet<MARK_XepHangTotNghiep_TC> MARK_XepHangTotNghiep_TC { get; set; }
		//public DbSet<MARK_XepLoaiChungChi> MARK_XepLoaiChungChi { get; set; }
		//public DbSet<MARK_XepLoaiChungChi_TC> MARK_XepLoaiChungChi_TC { get; set; }
		//public DbSet<MARK_XepLoaiHocTap> MARK_XepLoaiHocTap { get; set; }
		//public DbSet<MARK_XepLoaiHocTap_TC> MARK_XepLoaiHocTap_TC { get; set; }
		//public DbSet<MARK_XepLoaiHocTapThangdiem10_TC> MARK_XepLoaiHocTapThangdiem10_TC { get; set; }
        public DbSet<Mark_XetLenLop> Mark_XetLenLop { get; set; }
		//public DbSet<MARK_XetLenLopDanhSach> MARK_XetLenLopDanhSach { get; set; }
		//public DbSet<MARK_XetLenLopDanhSach_TC> MARK_XetLenLopDanhSach_TC { get; set; }
		//public DbSet<MARK_XetLenLopTongHop> MARK_XetLenLopTongHop { get; set; }
		//public DbSet<MARK_XetLenLopTongHop_TC> MARK_XetLenLopTongHop_TC { get; set; }
		public DbSet<PLAN_BoMon> PLAN_BoMon { get; set; }
		//public DbSet<PLAN_BoMonGiangVien> PLAN_BoMonGiangVien { get; set; }
		//public DbSet<PLAN_CaHoc> PLAN_CaHoc { get; set; }
		public DbSet<PLAN_ChucDanh> PLAN_ChucDanh { get; set; }
		public DbSet<PLAN_ChucVu> PLAN_ChucVu { get; set; }
		public DbSet<PLAN_ChuongTrinhDaoTao> PLAN_ChuongTrinhDaoTao { get; set; }
		public DbSet<PLAN_ChuongTrinhDaoTaoChiTiet> PLAN_ChuongTrinhDaoTaoChiTiet { get; set; }
		//public DbSet<PLAN_ChuongTrinhDaoTaoKienThuc> PLAN_ChuongTrinhDaoTaoKienThuc { get; set; }
        public DbSet<PLAN_ChuongTrinhDaoTaoMonTuongDuong> PLAN_ChuongTrinhDaoTaoMonTuongDuong { get; set; }
        public DbSet<PLAN_ChuongTrinhDaoTaoNhomTuChon> PLAN_ChuongTrinhDaoTaoNhomTuChon { get; set; }
        public DbSet<PLAN_ChuongTrinhDaoTaoRangBuoc> PLAN_ChuongTrinhDaoTaoRangBuoc { get; set; }
		//public DbSet<PLAN_ChuyenMon> PLAN_ChuyenMon { get; set; }
		public DbSet<PLAN_COSODAOTAO> PLAN_COSODAOTAO { get; set; }
		//public DbSet<PLAN_DangKyLichThi_TC> PLAN_DangKyLichThi_TC { get; set; }
		//public DbSet<PLAN_DangKyMonTinChi_TC> PLAN_DangKyMonTinChi_TC { get; set; }
		//public DbSet<PLAN_DangKyThucTap_TC> PLAN_DangKyThucTap_TC { get; set; }
		//public DbSet<PLAN_DuBaoLopTinChi_TC> PLAN_DuBaoLopTinChi_TC { get; set; }
		//public DbSet<PLAN_DuBaoLopTinChiTh_TC> PLAN_DuBaoLopTinChiTh_TC { get; set; }
		//public DbSet<PLAN_DuyetDangKySinhVien> PLAN_DuyetDangKySinhVien { get; set; }
		public DbSet<PLAN_GiaoVien> PLAN_GiaoVien { get; set; }
		public DbSet<PLAN_GiaoVienMonDay> PLAN_GiaoVienMonDay { get; set; }
		public DbSet<PLAN_HocHam> PLAN_HocHam { get; set; }
        public DbSet<PLAN_HocKyDangKy_TC> PLAN_HocKyDangKy_TC { get; set; }
		public DbSet<PLAN_HocVi> PLAN_HocVi { get; set; }
		//public DbSet<PLAN_KeHoachKhac_TC> PLAN_KeHoachKhac_TC { get; set; }
		//public DbSet<PLAN_KeHoachKyHieu_TC> PLAN_KeHoachKyHieu_TC { get; set; }
		//public DbSet<PLAN_KeHoachThi_TC> PLAN_KeHoachThi_TC { get; set; }
		//public DbSet<PLAN_LoaiLop_TC> PLAN_LoaiLop_TC { get; set; }
		//public DbSet<PLAN_LOAIPHONG> PLAN_LOAIPHONG { get; set; }
        public DbSet<PLAN_LoaiRangBuoc> PLAN_LoaiRangBuoc { get; set; }
		public DbSet<PLAN_LopTinChi_TC> PLAN_LopTinChi_TC { get; set; }
		//public DbSet<PLAN_LopTinChiGanLopHanhChinh_TC> PLAN_LopTinChiGanLopHanhChinh_TC { get; set; }
		//public DbSet<PLAN_MONDANGKY_HOCSOM> PLAN_MONDANGKY_HOCSOM { get; set; }
		//public DbSet<PLAN_MonDangKy_TC> PLAN_MonDangKy_TC { get; set; }
		public DbSet<PLAN_MonTinChi_TC> PLAN_MonTinChi_TC { get; set; }
		//public DbSet<PLAN_MonHocNhomHocPhan> PLAN_MonHocNhomHocPhan { get; set; }
        public DbSet<PLAN_PhamViDangKy_TC> PLAN_PhamViDangKy_TC { get; set; }
		//public DbSet<PLAN_PhamViDangKyHocPhan_TC> PLAN_PhamViDangKyHocPhan_TC { get; set; }
		public DbSet<PLAN_PhongHoc> PLAN_PhongHoc { get; set; }
		//public DbSet<PLAN_PhamViDangKyLop_TC> PLAN_PhamViDangKyLop_TC { get; set; }
		//public DbSet<PLAN_PLAN_KhungThoiGian_TC> PLAN_PLAN_KhungThoiGian_TC { get; set; }
        public DbSet<PLAN_QUYDINH_DANGKY> PLAN_QUYDINH_DANGKY { get; set; }
		//public DbSet<PLAN_QUYDINH_HOCSOM> PLAN_QUYDINH_HOCSOM { get; set; }
		//public DbSet<PLAN_QuyDinhSoTinChi_TC> PLAN_QuyDinhSoTinChi_TC { get; set; }
		//public DbSet<PLAN_QuyDinhSoTinChiSom_TC> PLAN_QuyDinhSoTinChiSom_TC { get; set; }
		//public DbSet<PLAN_SuKienKhacGiaoVienTinChi_TC> PLAN_SuKienKhacGiaoVienTinChi_TC { get; set; }
		//public DbSet<PLAN_SuKienKhacLopTinChi_TC> PLAN_SuKienKhacLopTinChi_TC { get; set; }
		//public DbSet<PLAN_SuKienKhacPhongTinChi_TC> PLAN_SuKienKhacPhongTinChi_TC { get; set; }
        public DbSet<PLAN_SukiensTinChi_TC> PLAN_SukiensTinChi_TC { get; set; }
		public DbSet<PLAN_TANG> PLAN_TANG { get; set; }
		//public DbSet<PLAN_ThoiGianTinChi> PLAN_ThoiGianTinChi { get; set; }
		//public DbSet<PLAN_ThoiGianTinChi_TC> PLAN_ThoiGianTinChi_TC { get; set; }
		//public DbSet<PLAN_TOANHA> PLAN_TOANHA { get; set; }
		public DbSet<STU_Bit> STU_Bit { get; set; }
		public DbSet<STU_CanBoLop> STU_CanBoLop { get; set; }
		public DbSet<STU_CapHoiDong> STU_CapHoiDong { get; set; }
		public DbSet<STU_CapKhenThuongKyLuat> STU_CapKhenThuongKyLuat { get; set; }
		public DbSet<STU_CapRenLuyen> STU_CapRenLuyen { get; set; }
		public DbSet<STU_ChucDanh> STU_ChucDanh { get; set; }
		//public DbSet<STU_ChungChiSinhVien> STU_ChungChiSinhVien { get; set; }
		public DbSet<STU_ChuyenNganh> STU_ChuyenNganh { get; set; }
		//public DbSet<STU_DanhHieu> STU_DanhHieu { get; set; }
		//public DbSet<STU_DanhhieuThiDuaCaNhan> STU_DanhhieuThiDuaCaNhan { get; set; }
		//public DbSet<STU_DanhhieuThiDuaTapthe> STU_DanhhieuThiDuaTapthe { get; set; }
		public DbSet<STU_DanhSach> STU_DanhSach { get; set; }
		//public DbSet<STU_DanhSachKhongThi> STU_DanhSachKhongThi { get; set; }
		public DbSet<STU_DanhSachLopTinChi> STU_DanhSachLopTinChi { get; set; }
		public DbSet<STU_DanhSachNganh2> STU_DanhSachNganh2 { get; set; }
		//public DbSet<STU_DanhSachTroCap> STU_DanhSachTroCap { get; set; }
		//public DbSet<STU_DanhSachXoa> STU_DanhSachXoa { get; set; }
		public DbSet<STU_DanToc> STU_DanToc { get; set; }
		public DbSet<STU_DiemRenLuyen> STU_DiemRenLuyen { get; set; }
		public DbSet<STU_DinhMuc> STU_DinhMuc { get; set; }
		public DbSet<STU_Doan> STU_Doan { get; set; }
		public DbSet<STU_DoiTuong> STU_DoiTuong { get; set; }
		public DbSet<STU_DoiTuongGiayto> STU_DoiTuongGiayto { get; set; }
		public DbSet<STU_DoiTuongHocBong> STU_DoiTuongHocBong { get; set; }
		public DbSet<STU_DoiTuongHocBongGiayto> STU_DoiTuongHocBongGiayto { get; set; }
		//public DbSet<STU_DuyetDangKySinhVien> STU_DuyetDangKySinhVien { get; set; }
		public DbSet<STU_GioiTinh> STU_GioiTinh { get; set; }
		public DbSet<STU_HanhVi> STU_HanhVi { get; set; }
		public DbSet<STU_He> STU_He { get; set; }
		public DbSet<STU_HeChuyenNganh> STU_HeChuyenNganh { get; set; }
		public DbSet<STU_HeSoRenLuyen> STU_HeSoRenLuyen { get; set; }
		public DbSet<STU_HoatDongXaHoi> STU_HoatDongXaHoi { get; set; }
		//public DbSet<STU_HoSoMacDinh> STU_HoSoMacDinh { get; set; }
		public DbSet<STU_HoSoNop> STU_HoSoNop { get; set; }
		public DbSet<STU_HoSoSinhVien> STU_HoSoSinhVien { get; set; }
		public DbSet<STU_HoSoSinhVienSub> STU_HoSoSinhVienSub { get; set; }
		//public DbSet<STU_HoSoSinhVienTemp> STU_HoSoSinhVienTemp { get; set; }
		//public DbSet<STU_HoSoSinhVienXoa> STU_HoSoSinhVienXoa { get; set; }
		public DbSet<STU_HoSoYeucau> STU_HoSoYeucau { get; set; }
		public DbSet<STU_Huyen> STU_Huyen { get; set; }
		public DbSet<STU_KhenThuong> STU_KhenThuong { get; set; }
		public DbSet<STU_KhenThuongSinhVien> STU_KhenThuongSinhVien { get; set; }
		public DbSet<STU_Khoa> STU_Khoa { get; set; }
		public DbSet<STU_KhuVuc> STU_KhuVuc { get; set; }
		public DbSet<STU_KyLuat> STU_KyLuat { get; set; }
		public DbSet<STU_KyLuatSinhVien> STU_KyLuatSinhVien { get; set; }
		public DbSet<STU_LoaiGiayTo> STU_LoaiGiayTo { get; set; }
		//public DbSet<STU_LoaiHocBong> STU_LoaiHocBong { get; set; }
		public DbSet<STU_LoaiKhenThuong> STU_LoaiKhenThuong { get; set; }
		public DbSet<STU_LoaiRenLuyen> STU_LoaiRenLuyen { get; set; }
		public DbSet<STU_Lop> STU_Lop { get; set; }
		public DbSet<STU_Nganh> STU_Nganh { get; set; }
		public DbSet<STU_NhanXetKy> STU_NhanXetKy { get; set; }
		public DbSet<STU_NhanXetNam> STU_NhanXetNam { get; set; }
		public DbSet<STU_NhomDoiTuong> STU_NhomDoiTuong { get; set; }
		public DbSet<STU_NoiNgoaiTru> STU_NoiNgoaiTru { get; set; }
		public DbSet<STU_PhongKyTucXa> STU_PhongKyTucXa { get; set; }
		public DbSet<STU_Phuong> STU_Phuong { get; set; }
		public DbSet<STU_QuocTich> STU_QuocTich { get; set; }
		public DbSet<STU_QuyHocBong> STU_QuyHocBong { get; set; }
		//public DbSet<STU_QuyHocBongPhanBo> STU_QuyHocBongPhanBo { get; set; }
		//public DbSet<STU_QuyHocBongPhanBoLop> STU_QuyHocBongPhanBoLop { get; set; }
		//public DbSet<STU_RangBuocNganhNhapHoc> STU_RangBuocNganhNhapHoc { get; set; }
		public DbSet<STU_ThanhPhanXuatThan> STU_ThanhPhanXuatThan { get; set; }
		public DbSet<STU_Tinh> STU_Tinh { get; set; }
		public DbSet<STU_ToaNhaKyTucXa> STU_ToaNhaKyTucXa { get; set; }
		//public DbSet<STU_TruongTHPT> STU_TruongTHPT { get; set; }
		//public DbSet<STU_XepLoaiHocBong> STU_XepLoaiHocBong { get; set; }
		//public DbSet<STU_XeploaiRenLuyen> STU_XeploaiRenLuyen { get; set; }
		//public DbSet<STU_XetHocBong> STU_XetHocBong { get; set; }
		public DbSet<STU_XuLy> STU_XuLy { get; set; }

		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<webpages_Group> webpages_Group { get; set; }
		public DbSet<webpages_Roles> webpages_Roles { get; set; }
		public DbSet<webpages_Groups_Roles> webpages_Groups_Roles { get; set; }
        public DbSet<ViewLopTinChi> ViewLopTinChi { get; set; }
        public DbSet<SCH_CauHinhThoiGian> SCH_CauHinhThoiGian { get; set; }
        public DbSet<CauHinhModel> Config { get; set; }
	}
}
