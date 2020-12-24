using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY.DataClass
{
    class tacGia
    {
        public string maTG { get; set; }
        public string tenTG { get; set; }
        public string website { get; set; }
        public string ghiChu { get; set; }
        public tacGia()
        {
            website = "null";
            ghiChu = "null";
        }
        public bool isNull()
        {
            return (string.IsNullOrWhiteSpace(maTG) || string.IsNullOrWhiteSpace(tenTG));
        }
    }
}
