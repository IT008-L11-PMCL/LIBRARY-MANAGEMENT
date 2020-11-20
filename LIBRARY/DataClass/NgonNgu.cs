using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY.DataClass
{
    class NgonNgu
    {
        public string maNN { get; set; }
        public string tenNN { get; set; }
        public bool isNull()
        {
            return (string.IsNullOrEmpty(maNN) || string.IsNullOrEmpty(tenNN));
        }
    }
}
