
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY.DataClass;

namespace LIBRARY.DAO
{
    class tacGia_DAO:dataProvider
    {
        public void delete(string maTG)
        {
            string sqlCommand = "delete from TACGIA where MaTG = '" + maTG + "'";
            Excute(sqlCommand);
        }
        public void update(tacGia t)
        {
            string sqlCommand = string.Format("update TACGIA set TenTG = '{0}', Website = '{1}', GhiChu = '{2} where MaTG = '{3}'", t.tenTG, t.website, t.ghiChu, t.maTG);
            Excute(sqlCommand);
        }
        public DataTable search(string s, string tuKhoa)
        {
            string sqlCommmand = string.Format("select * from TACGIA where {0} like '%{1}%'", s, tuKhoa);
            return dataTable(sqlCommmand);
        }
        public bool insert(tacGia t)
        {
            if (dataTable("select * from TACGIA where MaTG ='" + t.maTG + "'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into TACGIA values ('{0}','{1}','{2}','{3}')", t.maTG, t.tenTG, t.website, t.ghiChu);
            Excute(sqlCommand);
            return true;
        }
        public DataTable loadTG()
        {
            string sqlCommand = "select * from TACGIA";
            return dataTable(sqlCommand);
        }
    }
}
