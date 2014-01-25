using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortal.ViewModels
{
    public class LogViewModel
    {
        public Int64 Id { get; set; }

        [DisplayName("Thao tác")]
        public string Thao_tac { get; set; }

        [DisplayName("User")]
        public string Username { get; set; }

        [DisplayName("Tham số")]
        public string Tham_so { get; set; }

        [DisplayName("Địa chỉ IP")]
        public string Ip { get; set; }

        [DisplayName("Thời gian")]
        public DateTime Thoi_gian { get; set; }

        public int UserId { get; set; }
    }
}
