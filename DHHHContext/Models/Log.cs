using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortal.Models
{
    [Table("webpages_Log")]
    public class Log
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [ForeignKey("UserProfile")]
        public int User_id { get; set; }
        
        public string User_ip { get; set; }
        
        public int Thao_tac { get; set; }
        
        public DateTime Thoi_gian { get; set; }
        
        public string Tham_so { get; set; }

        public virtual UserProfile UserProfile { get; set; }

    }
}
