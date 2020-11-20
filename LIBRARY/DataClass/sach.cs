﻿using System;
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
        public int soLuong { get; set; }
        public string ngonNgu { get; set; }
        public string maXB { get; set; }
        public string maTG { get; set; }
        public string maTL { get; set; }
        public string maVT { get; set; }
        public int tinhTrang { get; set; }
        public bool isNull()
        {
            return (string.IsNullOrEmpty(maSach) || string.IsNullOrEmpty(tenSach) || string.IsNullOrEmpty(namXB) || string.IsNullOrEmpty(soLuong.ToString()) || string.IsNullOrEmpty(ngonNgu) || string.IsNullOrEmpty(maXB) || string.IsNullOrEmpty(maTG) || string.IsNullOrEmpty(maTL) || string.IsNullOrEmpty(maVT) || string.IsNullOrEmpty(tinhTrang.ToString()));
        }    
    }
}
