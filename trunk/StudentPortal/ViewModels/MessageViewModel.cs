using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.ViewModels
{
    public class MessageViewModel
    {
        public int ID { get; set; }
        
        [DisplayName("Tiêu đề")]
        public string Title { get; set; }

        [DisplayName("Nội dung")]
        public string Contents { get; set; }

        [DisplayName("Từ")]
        public string From { get; set; }

        [DisplayName("Đến")]
        public string To { get; set; }

        [DisplayName("Ngày gửi")]
        public DateTime Postdate { get; set; }

        [DisplayName("STT")]
        public int index { get; set; }
    }
}