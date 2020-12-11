using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY.DataClass
{
    class nhanVien
    {
        public string maNV { get; set; }
        public string hoTen { get; set; }
        public string ngaySinh { get; set; }
        public string sdt { get; set; }
        //public string userName { get; set; }
        public string passWord { get; set; }
        public bool isNull()
        {
            return (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(ngaySinh) || string.IsNullOrWhiteSpace(passWord) || string.IsNullOrWhiteSpace(sdt));
        }
        

    }
}
