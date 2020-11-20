using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Windows.Forms;
using LIBRARY.DataClass;

namespace LIBRARY.DAO
{
    class sach_DAO : dataProvider
    {
        public void delete(string maSach)
        {
            string sqlCommand = "delete from SACH where MaSach = '" + maSach + "'";
            Excute(sqlCommand);
        }
        public void update(sach s) 
        {
            string sqlCommand = string.Format("update SACH set Ten = N'{0}', NamXB = '{1}', SoLuong = {2}, NgonNgu = '{3}',MaNX = '{4}',MaTG = '{5}', MaTL ='{6}',MaVT = '{7}',TinhTrang = {8} where MaSach = '{9}' ", s.tenSach, s.namXB, s.soLuong, s.ngonNgu, s.maXB, s.maTG, s.maTL, s.maVT, s.tinhTrang, s.maSach);
            Excute(sqlCommand);
        }
        public DataTable search(string s,string tuKhoa)
        {
            string sqlCommmand = string.Format("select MaSach, Ten, NamXB, MaNN, TenNXB, TenTG, TenTL, Khu,Ke,Ngan, TinhTrang from SACH, NHAXUATBAN, TACGIA, THELOAI, VITRI where SACH.MaXB = NHAXUATBAN.MaNXB and SACH.MaTG = TACGIA.MaTG and SACH.MaTL = THELOAI.MaTL and SACH.MaVT = VITRI.MaVT and {0} like '%{1}%'", s, tuKhoa);
            return dataTable(sqlCommmand);
        }
        public bool insert(sach s)
        {
            if (dataTable("select * from SACH where MaSach ='" + s.maSach + "'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into SACH values ('{0}',N'{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}',{9})", s.maSach, s.tenSach, s.namXB, s.soLuong, s.ngonNgu, s.maXB, s.maTG, s.maTL,s.maVT, s.tinhTrang);
            Excute(sqlCommand);    
            return true;
        }
        public DataTable loadSach() 
        {
            string sqlCommand = "select * from SACH";
            return dataTable(sqlCommand);
        }
    }
}
