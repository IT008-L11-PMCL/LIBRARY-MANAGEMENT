using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY.DataClass
{
    class docGia
    {
        public string maDG { get; set; }
        public string tenDG { get; set; }
        public string diaChi { get; set; }
        public string maThe { get; set; }
        public string ghiChu { get; set; }

        public bool isNull()
        {
            return (string.IsNullOrEmpty(maDG) || string.IsNullOrEmpty(tenDG) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(maThe) || string.IsNullOrEmpty(ghiChu));
        }
    }
}
