//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace StudentPortal
{
    using System;
    using System.Collections.Generic;
    [Table("STU_DanToc")]
    public partial class STU_DanToc
    {
        [Key]
        public int ID_dan_toc { get; set; }
		
		[Display(Name = "Mã dân tộc")]
        public string Ma_dan_toc { get; set; }
		
		[Display(Name = "Dân tộc")]
        public string Dan_toc { get; set; }
		
		[Display(Name = "Dân tộc EN")]
        public string Dan_toc_en { get; set; }
    }
}
