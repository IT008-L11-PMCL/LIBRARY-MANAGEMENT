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
            string sqlCommand = string.Format("update SACH set Ten = N'{0}', NamXB = '{1}', MaXB = '{2}',MaTG = '{3}', MaTL ='{4}',MaVT = '{5}',TinhTrang = N'{6}', MaNN = '{7}' where MaSach = '{8}' ", s.tenSach, s.namXB, s.maXB, s.maTG, s.maTL, s.maVT, s.tinhTrang,s.ngonNgu, s.maSach);
            Excute(sqlCommand);
        }
        public DataTable search(string s,string tuKhoa)
        {
            string sqlCommmand = string.Format("select * from SACH where {0} like N'%{1}%'", s, tuKhoa);
            return dataTable(sqlCommmand);
        }
        public bool insert(sach s)
        {
            if (dataTable("select * from SACH where MaSach ='" + s.maSach + "'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into SACH values ('{0}',N'{1}','{2}','{3}','{4}','{5}','{6}',N'{7}','{8}')", s.maSach, s.tenSach, s.namXB, s.maXB, s.maTG, s.maTL,s.maVT, s.tinhTrang,s.ngonNgu);
            Excute(sqlCommand);    
            return true;
        }
        public DataTable loadSach() 
        {
            string sqlCommand = "select * from SACH";
            return dataTable(sqlCommand);
        }
        public DataTable loadSachCoSan()
        {
            string sqlCommand = "select * from SACH where TinhTrang = N'Có sẵn'";
            return dataTable(sqlCommand);
        }

        public DataTable loadSachDaMuon()
        {
            string sqlCommand = "select * from SACH where TinhTrang = N'Đã mượn'";
            return dataTable(sqlCommand);
        }
        public DataTable loadSachTrungBay()
        {
            string sqlCommand = "select * from SACH where TinhTrang = N'Trưng bày'";
            return dataTable(sqlCommand);
        }
        public DataTable loadSachMat()
        {
            string sqlCommand = "select * from SACH where TinhTrang = N'Mất'";
            return dataTable(sqlCommand);
        }

        public void updateStatus(string maSach, string b)
        {
            string sqlcommand = "update SACH set TinhTrang = N'" + b + "' where MaSach = '" + maSach + "'";
            Excute(sqlcommand);                 
        }  


        
        public int total()
        {
            string sqlCommand = "select count(distinct MaSach) from SACH";
            int t = (int)ExcuteScalar(sqlCommand);
            return t;
        }
        public int available()
        {
            string sqlCommand = "select count(distinct MaSach) from SACH where TinhTrang = N'Có sẵn'";
            int t = (int)ExcuteScalar(sqlCommand);
            return t;
        }
        public int borrowing()
        {
            string sqlCommand = "select count(distinct MaSach) from SACH where TinhTrang = N'Đã mượn'";
            int t = (int)ExcuteScalar(sqlCommand);
            return t;
        }
        public int display()
        {
            string sqlCommand = "select count(distinct MaSach) from SACH where TinhTrang = N'Trưng bày'";
            int t = (int)ExcuteScalar(sqlCommand);
            return t;
        }

        public int lost()
        {
            string sqlCommand = "select count(distinct MaSach) from SACH where TinhTrang = N'Mất'";
            int t = (int)ExcuteScalar(sqlCommand);
            return t;
        }
    }
}
