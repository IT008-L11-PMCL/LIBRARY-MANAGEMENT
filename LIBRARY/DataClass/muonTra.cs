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
        public string maSach { get; set; }
        public string maNV { get; set; }
        public string ngayMuon { get; set; }
        public string ngayTra { get; set; }
        public string hinhThuc { get; set; }
        public int soNgayMuon { get; set; }

        public bool isNull()
        {
            return (string.IsNullOrEmpty(maMuon) || string.IsNullOrEmpty(maThe) || string.IsNullOrEmpty(maSach) || string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(ngayTra) || string.IsNullOrEmpty(ngayMuon) || string.IsNullOrEmpty(hinhThuc) || string.IsNullOrEmpty(soNgayMuon.ToString()));
        }
    }
}
