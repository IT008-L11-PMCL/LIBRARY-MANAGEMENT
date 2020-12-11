
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY.DataClass;

namespace LIBRARY.DAO
{
    class NXB_DAO:dataProvider
    {
        public void delete(string maNXB)
        {
            string sqlCommand = "delete from NHAXUATBAN where MaNXB = '" + maNXB + "'";
            Excute(sqlCommand);
        }
        public void update(NXB n)
        {
            string sqlCommand = string.Format("update NHAXUATBAN set TenNXB = '{0}', DiaChi = '{1}', Email = '{2}, ThongTin = '{3} where MaNXB = '{4}'", n.tenNXB, n.diaChi, n.email, n.thongTin, n.maNXB);
            Excute(sqlCommand);
        }
        public DataTable search(string s, string tuKhoa)
        {
            string sqlCommmand = string.Format("select * from NHAXUATBAN where {0} like '%{1}%'", s, tuKhoa);
            return dataTable(sqlCommmand);
        }
        public DataTable search(string tuKhoa)
        {
            string sqlCommmand = string.Format("select * from NHAXUATBAN where MaNXB = '{0}'", tuKhoa);
            return dataTable(sqlCommmand);
        }

        public bool insert(NXB n)
        {
            if (dataTable("select * from NHAXUATBAN where MaNXB ='" + n.maNXB + "'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into NHAXUATBAN values ('{0}',N'{1}',N'{2}','{3}',N'{4}')", n.maNXB, n.tenNXB, n.diaChi, n.email, n.thongTin);
            Excute(sqlCommand);
            return true;
        }
        public DataTable loadNXB()
        {
            string sqlCommand = "select * from NHAXUATBAN";
            return dataTable(sqlCommand);
        }        
    }
}
