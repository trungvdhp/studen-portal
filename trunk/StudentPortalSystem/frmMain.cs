using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentPortal;
using StudentPortal.Models;
using StudentPortal.Lib;

namespace StudentPortalSystem
{
    
    public partial class frmMain : Form
    {
        DateTime lastRun;
        bool started = false;
        List<STU_DanhSach> SinhViens;
        DHHHContext db;
        List<MARK_XepHangNamDaoTao_TC> xephang;
        Dictionary<int, float> dicDiemDK = new Dictionary<int, float>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dicDiemDK.Add(1, 0.8f);
            dicDiemDK.Add(2, 0.8f);
            dicDiemDK.Add(3, 0.8f);
            dicDiemDK.Add(4, 0.8f);
            dicDiemDK.Add(5, 0.8f);
            dicDiemDK.Add(6, 0.8f);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (started)
            {
                started = false;
                btnBatDau.Text = "Bắt đầu";
                numericUpDown1.ReadOnly = false;
                comboBox1.Enabled = true;
                dateTimePicker1.Enabled = true;
            }
            else
            {
                started = true;
                btnBatDau.Text = "Dừng";
                numericUpDown1.ReadOnly = true;
                comboBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                timer1.Start();
                lastRun = dateTimePicker1.Value;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool run = false;
            switch (Convert.ToInt32(comboBox1.SelectedValue))
            {
                case 0:
                    if(DateTime.Now>=lastRun.AddHours((int)numericUpDown1.Value))
                        run=true;
                    break;
                case 1:
                    if (DateTime.Now >= lastRun.AddDays((int)numericUpDown1.Value))
                        run=true;
                    break;
                case 2:
                    if (DateTime.Now >= lastRun.AddDays(7*(int)numericUpDown1.Value))
                        run=true;
                    break;
                case 3:
                    if (DateTime.Now >= lastRun.AddMonths((int)numericUpDown1.Value))
                        run=true;
                    break;
            }
            if (run)
            {
                db = new DHHHContext();
                SinhViens = db.STU_DanhSach.Where(t => t.Trang_thai == 0 && t.Da_tot_nghiep==false).ToList();
                backgroundWorker1.RunWorkerAsync();
                xephang = db.MARK_XepHangNamDaoTao_TC.ToList();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var sinhvien in SinhViens)
            {
                var bangdiem = SinhVien.GetBangDiem(sinhvien.ID_sv, sinhvien.STU_Lop.ID_dt);
                var TBMHTHocKyCuoi = bangdiem.Where(t => t.Ma_mon.Length == 0).OrderByDescending(t => t.Nam_hoc).ThenByDescending(t => t.Hoc_ky).First().Z;
                var kythu = SinhVien.getHocKy(bangdiem, xephang);

                // Canh bao hoc tap
                if (TBMHTHocKyCuoi < dicDiemDK[kythu] )
                {
                    var str = String.Format(@"Học kỳ này bạn có thể bị cảnh cáo học tập do điểm trung bình môn học tập hiện tại là {0:0.0}, nhỏ hơn mức trung bình học tập tối thiểu. ", TBMHTHocKyCuoi);
                    db.Inbox.Add(new InboxModel{
                        Title = "Cảnh báo học tập",
                        Contents = str,
                        Warning=true,
                        Type = InboxModel.INBOX,
                    });
                }

                var bienlai = SinhVien.GetBienLai(sinhvien.ID_sv, sinhvien.STU_Lop.ID_dt).Where(t=>t.Chua_dong).ToList();
                if (bienlai.Count()>0)
                {
                    var str = "Các lớp học phần còn nợ học phí: \n";
                    foreach (var mon in bienlai)
                    {
                        str += string.Format("{0}: {1}\n",mon.Ten_thu_chi,mon.So_tien);
                    }
                    db.Inbox.Add(new InboxModel
                    {
                        Title = "Cảnh báo học phí",
                        Contents =str,
                        Warning = true,
                        Type = InboxModel.INBOX,
                    });
                }
                db.SaveChanges();
            }
        }

    }
}
