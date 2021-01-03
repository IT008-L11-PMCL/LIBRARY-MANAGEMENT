using LIBRARY.DataClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY.DAO
{
    class theTV_DAO : dataProvider
    {
        public void delete(string maThe)
        {
            string sqlCommand = "delete from THETHUVIEN where MaThe = '" + maThe + "'";
            Excute(sqlCommand);
        }
        public void update(theTV t)
        {
            string sqlCommand = string.Format("update THETHUVIEN set NgayBatDau = '{0}', NgayHetHan = '{1}', GhiChu = N'{2}', TrangThai = N'{3}' where MaThe = '{4}'", t.ngayBD, t.ngayHH, t.ghiChu, t.trangThai, t.maThe);
            Excute(sqlCommand);
        }
        public DataTable search(string s, string tuKhoa)
        {
            string sqlCommmand = string.Format("select * from THETHUVIEN where {0} like '%{1}%'", s, tuKhoa);
            return dataTable(sqlCommmand);
        }
        public bool insert(theTV t)
        {
            if (dataTable("select * from THETHUVIEN where MaThe ='" + t.maThe + "'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into THETHUVIEN values ('{0}','{1}','{2}',N'{3}',N'{4}')", t.maThe, t.ngayBD, t.ngayHH, t.ghiChu, t.trangThai);
            Excute(sqlCommand);
            return true;
        }
        public DataTable loadThe()
        {
            string sqlCommand = "select * from THETHUVIEN";
            return dataTable(sqlCommand);
        }

        public void updateStatus(string maThe, string b)
        {
            string sqlcommand = "update THETHUVIEN set TrangThai = N'" + b + "' where MaThe = '" + maThe + "'";
            Excute(sqlcommand);
        }

        public DataTable getListAvai()
        {
            string sqlCommand = "select * from THETHUVIEN where TrangThai = N'Mới'";
            return dataTable(sqlCommand);
        }

        public DataTable getListUsing()
        {
            string sqlCommand = "select * from THETHUVIEN where TrangThai = N'Đang sử dụng'";
            return dataTable(sqlCommand);
        }
    } 
}
