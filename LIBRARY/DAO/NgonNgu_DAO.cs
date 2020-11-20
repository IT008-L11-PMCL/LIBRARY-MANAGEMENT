
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY.DataClass;

namespace LIBRARY.DAO
{
    class NgonNgu_DAO:dataProvider
    {
        public void delete(string maNN)
        {
            string sqlCommand = "delete from NGONNGU where MaNN = '" + maNN + "'";
            Excute(sqlCommand);
        }
        public void update(NgonNgu n)
        {
            string sqlCommand = string.Format("update NGONNGU set TenNN = N'{0}' where MaNN = '{1}' ", n.tenNN, n.maNN);
            Excute(sqlCommand);
        }
        public DataTable search(string s, string tuKhoa)
        {
            string sqlCommmand = string.Format("select * from NGONNGU where {0} like '%{1}%'", s, tuKhoa);
            return dataTable(sqlCommmand);
        }
        public bool insert(NgonNgu n)
        {
            if (dataTable("select * from NGONNGU where MaNN ='" + n.maNN + "'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into NGONNGU values ('{0}',N'{1}')", n.maNN, n.tenNN);
            Excute(sqlCommand);
            return true;
        }
        public DataTable loadNN()
        {
            string sqlCommand = "select * from NGONNGU";
            return dataTable(sqlCommand);
        }
    }
}
