﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudentPortal.Models;

namespace StudentPortal
{
    using System;
    using System.Collections.Generic;
    [Table("tbl_inbox")]
    public partial class InboxModel
    {

        public const int INBOX = 0;
        public const int OUTBOX = 1;

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name="Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]
        public string Contents { get; set; }

        [Display(Name = "Ngày gửi")]
        public DateTime Postdate { get; set; }

        [Display(Name = "Từ")]
        [ForeignKey("FromUser")]
        public int From { get; set; }

        [Display(Name = "Đến")]
        [ForeignKey("ToUser")]
        public int To { get; set; }

        [Display(Name = "Đọc")]
        public bool Status { get; set; }

        public bool Warning { get; set; }

        public byte Type { get; set; }

        public virtual UserProfile FromUser { get; set; }

        public virtual UserProfile ToUser { get; set; }
    }
}
