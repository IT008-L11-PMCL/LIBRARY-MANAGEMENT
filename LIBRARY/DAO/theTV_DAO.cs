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
                string sqlCommand = string.Format("update THETHUVIEN set NgayBatDau = '{0}', NgayHetHan = '{1}', GhiChu = N'{2}' where MaThe = '{3}'", t.ngayBD, t.ngayHH, t.ghiChu, t.maThe);
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
                string sqlCommand = string.Format("insert into THETHUVIEN values ('{0}','{1}','{2}',N'{3}')", t.maThe, t.ngayBD, t.ngayHH, t.ghiChu);
                Excute(sqlCommand);
                return true;
            }
            public DataTable loadThe()
            {
                string sqlCommand = "select * from THETHUVIEN";
                return dataTable(sqlCommand);
            }
        }
}
