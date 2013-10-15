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
        int timer2count = 0;
        STU_DanhSach svHienTai;
        bool running = false;
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
                reloadBtnBatDau();
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
                switch (Convert.ToInt32(comboBox1.SelectedValue))
                {
                    case 0:
                        lastRun = lastRun.AddHours(-(int)numericUpDown1.Value-1);
                        break;
                    case 1:
                        lastRun = lastRun.AddDays(-(int)numericUpDown1.Value - 1);
                        break;
                    case 2:
                        lastRun = lastRun.AddDays(-7 * (int)numericUpDown1.Value - 1);
                        break;
                    case 3:
                        lastRun = lastRun.AddMonths(-(int)numericUpDown1.Value - 1);
                        break;
                }
                timer2count = 0;
            }
        }

        private void reloadBtnBatDau()
        {
            started = false;
            btnBatDau.Text = "Bắt đầu";
            numericUpDown1.ReadOnly = false;
            comboBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (running) return;
            bool run = false;
            switch (Convert.ToInt32(comboBox1.SelectedValue))
            {
                case 0:
                    if (DateTime.Now >= lastRun.AddHours((int)numericUpDown1.Value))
                        run = true;
                    break;
                case 1:
                    if (DateTime.Now >= lastRun.AddDays((int)numericUpDown1.Value))
                        run = true;
                    break;
                case 2:
                    if (DateTime.Now >= lastRun.AddDays(7 * (int)numericUpDown1.Value))
                        run = true;
                    break;
                case 3:
                    if (DateTime.Now >= lastRun.AddMonths((int)numericUpDown1.Value))
                        run = true;
                    break;
            }
            if (run)
            {
                running = true;
                db = new DHHHContext();
                SinhViens = db.STU_DanhSach.Where(t => t.Trang_thai == 0 && t.Da_tot_nghiep == false).ToList();
                backgroundWorker1.RunWorkerAsync();
                xephang = db.MARK_XepHangNamDaoTao_TC.ToList();
                progressBar1.Maximum = SinhViens.Count;
                toolStripStatusLabel1.Text = String.Format("Tổng số sinh viên {0}", SinhViens.Count);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            foreach (var sinhvien in SinhViens)
            {
                svHienTai = sinhvien;
                var bangdiem = SinhVien.GetBangDiem(sinhvien.ID_sv, sinhvien.STU_Lop.ID_dt);
                var TBMHTHocKyCuoi = bangdiem.Where(t => t.Ma_mon == null).OrderByDescending(t => t.Nam_hoc).ThenByDescending(t => t.Hoc_ky).First().Z;
                var namthu = SinhVien.getNamHocThu(bangdiem, xephang);

                // Canh bao hoc tap
                if (TBMHTHocKyCuoi < dicDiemDK[namthu])
                {
                    var str = String.Format(@"Học kỳ này bạn có thể bị cảnh cáo học tập do điểm trung bình môn học tập hiện tại là {0:0.0}, nhỏ hơn mức trung bình học tập tối thiểu. ", TBMHTHocKyCuoi);
                    db.Inbox.Add(new InboxModel
                    {
                        Title = "Cảnh báo học tập",
                        To = sinhvien.ID_sv,
                        From = 10,
                        Contents = str,
                        Warning = true,
                        Type = InboxModel.INBOX,
                        Postdate = DateTime.Now
                    });
                }

                var bienlai = SinhVien.GetBienLai(sinhvien.ID_sv, sinhvien.STU_Lop.ID_dt).Where(t => t.Chua_dong).ToList();
                if (bienlai.Count() > 0)
                {
                    var str = "Các lớp học phần còn nợ học phí: \n";
                    foreach (var mon in bienlai)
                    {
                        str += string.Format("{0}: {1}\n", mon.Noi_dung, mon.So_tien);
                    }
                    db.Inbox.Add(new InboxModel
                    {
                        Title = "Cảnh báo học phí",
                        Contents = str,
                        Warning = true,
                        Type = InboxModel.INBOX,
                        To = sinhvien.ID_sv,
                        From = 10,
                        Postdate = DateTime.Now
                    });
                }
                db.SaveChanges();
                backgroundWorker1.ReportProgress(i++);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (timer2count == 0) timer2.Start();
            progressBar1.Value = e.ProgressPercentage;
            label6.Text = String.Format("{0}/{1}", e.ProgressPercentage, progressBar1.Maximum);
            try
            {
                label1.Text = String.Format("Đang kiểm tra sinh viên {0} ({1})...", svHienTai.STU_HoSoSinhVien.Ho_ten, svHienTai.STU_HoSoSinhVien.Ma_sv);
            }
            catch (Exception)
            {
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2count++;
            if (started)
            {
                label5.Text = String.Format("{0}", TimeSpan.FromSeconds(timer2count).ToString("c"));
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            running = false;
            timer2.Stop();
            toolStripStatusLabel1.Text = String.Format("Tổng thời gian: {0}", TimeSpan.FromSeconds(timer2count).ToString("c"));
            timer2count = 0;
            //reloadBtnBatDau();
            lastRun = DateTime.Now;
        }

    }
}
