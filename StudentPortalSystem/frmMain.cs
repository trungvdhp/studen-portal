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
        bool pause = false;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dicDiemDK.Add(1, 0.8f);
            dicDiemDK.Add(2, 1.0f);
            dicDiemDK.Add(3, 1.0f);
            dicDiemDK.Add(4, 1.2f);
            dicDiemDK.Add(5, 1.4f);
            dicDiemDK.Add(6, 1.4f);
            comboBox1.SelectedIndex = 0;
            timer2count = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (started)
            {
                btnBatDau.Text = "Tiếp tục";
                pause = true;
                btnBatDau.Enabled = false;
                backgroundWorker1.CancelAsync();
            }
            else
            {
                if (pause)
                {
                    pause = false;
                    //backgroundWorker1.RunWorkerAsync();
                    //return;
                }
                started = true;
                btnBatDau.Text = "Tạm dừng";
                numericUpDown1.ReadOnly = true;
                comboBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                timer1.Start();
                timer2.Start();
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
                label1.Text = "Đang tải dữ liệu...";
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
            for (int i = progressBar1.Value; i < SinhViens.Count && !pause;i++ )
            {
                var sinhvien = SinhViens[i];
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
                backgroundWorker1.ReportProgress(i);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
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
            if(started) 
                toolStripStatusLabel1.Text = String.Format("Tổng thời gian: {0}", TimeSpan.FromSeconds(timer2count).ToString("c"));
            if (!pause)
            {
                timer2count = 0;
                reloadBtnBatDau();
            }
            btnBatDau.Enabled = true;
            started = false;
            lastRun = DateTime.Now;
        }

        private void comboBox1_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

    }
}
