using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY.DataClass
{
    class theLoai
    {
        public string maTL { get; set; }
        public string tenTL { get; set; }
        public bool isNull()
        {
            return (string.IsNullOrEmpty(maTL) || string.IsNullOrEmpty(tenTL));
        }
    }
}
