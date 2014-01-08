using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortal.Models
{
    public class Log
    {
        public int Id { get; set; }
        public int user_id { get; set; }
        public string user_ip { get; set; }
        public string action { get; set; }
        public DateTime time { get; set; }
        public string param { get; set; }

    }
}
