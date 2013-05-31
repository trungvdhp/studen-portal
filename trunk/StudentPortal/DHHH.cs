using System.Data.Entity;

namespace StudentPortal
{
    public class DHHH : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<StudentPortal.DHHH>());

        public DHHH() : base("name=DHHH")
        {
        }

        public DbSet<STU_CapRenLuyen> STU_CapRenLuyen { get; set; }

        public DbSet<STU_DanhhieuThiDuaCaNhan> STU_DanhhieuThiDuaCaNhan { get; set; }

        public DbSet<STU_DanhHieu> STU_DanhHieu { get; set; }

        public DbSet<STU_DanhSach> STU_DanhSach { get; set; }

        public DbSet<STU_Lop> STU_Lop { get; set; }

        public DbSet<STU_DanhSachKhongThi> STU_DanhSachKhongThi { get; set; }

        public DbSet<MARK_MonHoc> MARK_MonHoc { get; set; }

        public DbSet<STU_DanhSachLopTinChi> STU_DanhSachLopTinChi { get; set; }

        public DbSet<PLAN_LopTinChi_TC> PLAN_LopTinChi_TC { get; set; }

        public DbSet<STU_HoSoSinhVien> STU_HoSoSinhVien { get; set; }

        public DbSet<STU_DanhSachNganh2> STU_DanhSachNganh2 { get; set; }

        public DbSet<STU_DoiTuong> STU_DoiTuong { get; set; }

        public DbSet<STU_DanhSachTroCap> STU_DanhSachTroCap { get; set; }

        public DbSet<STU_DanhSachXoa> STU_DanhSachXoa { get; set; }
    }
}
