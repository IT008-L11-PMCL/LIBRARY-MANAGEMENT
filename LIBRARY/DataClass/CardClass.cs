using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY.DataClass
{
    class theTV
    {
        public string maThe { get; set; }
        public string ngayBD { get; set; }
        public string ngayHH { get; set; }
        public string ghiChu { get; set; }
        public string trangThai { get; set; }

        public theTV()
        {
            trangThai = "Mới";
            ghiChu = "null";
        }
        public bool isNull()
        {
            return (string.IsNullOrEmpty(maThe));
        }
    }
}
