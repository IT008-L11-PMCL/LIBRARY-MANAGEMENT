using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRARY.DataClass
{
    class sach
    {
        public string maSach { get; set; }
        public string tenSach { get; set; }
        public string namXB { get; set; }
        public string ngonNgu { get; set; }
        public string maXB { get; set; }
        public string maTG { get; set; }
        public string maTL { get; set; }
        public string maVT { get; set; }
        public string tinhTrang { get; set; }
        public bool isNull()
        {
            return (string.IsNullOrEmpty(maSach) || string.IsNullOrEmpty(tenSach));
        }    
    }
}
