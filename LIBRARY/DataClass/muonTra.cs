using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY.DataClass
{
    class muonTra
    {
        public string maMuon { get; set; }
        public string maThe { get; set; }
        public string maNV { get; set; }
        public string ngayMuon { get; set; }
        public string ngayHan { get; set; }
        public string maSach { get; set; }
        public string ngayTra { get; set; }
        public bool trangThai { get; set; }
        public string ghiChu { get; set; }

        public muonTra()
        {
            trangThai = false;
            ghiChu = "null";
        }

        //public bool isNull()
        //{
        //    return (string.IsNullOrEmpty(maMuon) || string.IsNullOrEmpty(maThe) || string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(ngayHan) || string.IsNullOrEmpty(ngayMuon) || string.IsNullOrEmpty(ngayTra) || string.IsNullOrEmpty(ghiChu));
        //}
    }
}
