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
        public bool isNull()
        {
            return (string.IsNullOrEmpty(maThe) || string.IsNullOrEmpty(ngayBD) || string.IsNullOrEmpty(ngayHH) || string.IsNullOrEmpty(ghiChu));
        }
    }
}
