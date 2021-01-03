
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LIBRARY.DataClass;

namespace LIBRARY.DAO
{
    class docGia_DAO: dataProvider   
    {
        public void delete(string maDG)
        {
            string sqlCommand = "delete from DOCGIA where MaDG = '" + maDG + "'";
            Excute(sqlCommand);
        }
        public void update(docGia d)
        {
            string sqlCommand = string.Format("update DOCGIA set TenDG = N'{0}',DiaChi = N'{1}' ,GhiChu = N'{2}' where MaDG = '{3}'", d.tenDG, d.diaChi, d.ghiChu, d.maDG);
            Excute(sqlCommand);
        }
        public DataTable search(string s, string tuKhoa)
        {
            string sqlCommmand = string.Format("select * from DOCGIA where {0} like '%{1}%'", s, tuKhoa);
            return dataTable(sqlCommmand);
        }
        public bool insert(docGia d)
        {
            if (dataTable("select * from DOCGIA where MaDG ='" + d.maDG + "'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into DOCGIA values ('{0}',N'{1}',N'{2}','{3}',N'{4}')", d.maDG, d.tenDG, d.diaChi, d.maThe, d.ghiChu);
            Excute(sqlCommand);
            return true;
        }
        public DataTable loadDocGia()
        {
            string sqlCommand = "select * from DOCGIA";
            return dataTable(sqlCommand);
        }


    }
}
