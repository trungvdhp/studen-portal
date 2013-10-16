using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.ViewModels
{
    public class InboxViewModel
    {

        public int Id { get; set; }

        [DisplayName("Tiêu đề")]
        public string Title { get; set; }

        [DisplayName("Ngày gửi")]
        public DateTime Postdate { get; set; }

        [DisplayName("Người gửi")]
        public string From { get; set; }

        [DisplayName("Nội dung")]
        public string Contents { get; set; }

        public string Link { get; set; }

        public string FromUser { get; set; }

        public byte Type { get; set; }
    }
}