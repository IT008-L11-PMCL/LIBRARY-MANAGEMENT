using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY.DataClass
{
    class CTMT
    {
        public string maMuon { get; set; }
        public string maSach { get; set; }
        public string ngayTra { get; set; }
        public string trangThai { get; set; }
        public string ghiChu { get; set; }
        public CTMT()
        {
            trangThai = "0";
            ghiChu = "null";
        }
    }
}
