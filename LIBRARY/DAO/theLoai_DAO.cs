
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY.DataClass;

namespace LIBRARY.DAO
{
    class theLoai_DAO:dataProvider
    {
        public void delete(string maTL)
        {
            string sqlCommand = "delete from THELOAI where MaTL = '" + maTL + "'";
            Excute(sqlCommand);
        }
        public void update(theLoai t)
        {
            string sqlCommand = string.Format("update THELOAI set TenTL = '{0}' where MaTL = '{1}'", t.tenTL, t.maTL);
            Excute(sqlCommand);
        }
        public DataTable search(string s, string tuKhoa)
        {
            string sqlCommmand = string.Format("select * from THELOAI where {0} like '%{1}%'", s, tuKhoa);
            return dataTable(sqlCommmand);
        }
        public bool insert(theLoai t)
        {
            if (dataTable("select * from THELOAI where MaTL ='" + t.maTL + "'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into THELOAI values ('{0}','{1}')",t.maTL,t.tenTL);
            Excute(sqlCommand);
            return true;
        }
        public DataTable loadTL()
        {
            string sqlCommand = "select * from THELOAI";
            return dataTable(sqlCommand);
        }
    }
}
