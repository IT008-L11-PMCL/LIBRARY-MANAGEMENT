using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY.DataClass
{
    class viTri
    {
        public string maVT { get; set; }
        public string khu { get; set; }
        public string ngan { get; set; }
        public string ke { get; set; }

        public viTri()
        {
            khu = ke = ngan = "null";
        }    

        public bool isNull()
        {
            return (string.IsNullOrWhiteSpace(maVT) || string.IsNullOrWhiteSpace(khu) || string.IsNullOrWhiteSpace(ke) || string.IsNullOrWhiteSpace(ngan));
        }
    }
}
