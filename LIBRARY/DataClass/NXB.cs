using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY.DataClass
{
    class NXB
    {
        public string maNXB { get;set; }
        public string tenNXB { get; set; }
        public string diaChi { get; set; }
        public string email { get; set; }
        public string thongTin { get; set; }
        public NXB()
        {
            diaChi = "null";
            email = "null";
            thongTin = "null";
        }
        public bool isNull()
        {
            return (string.IsNullOrEmpty(maNXB) || string.IsNullOrEmpty(tenNXB));
        }
    }
}
