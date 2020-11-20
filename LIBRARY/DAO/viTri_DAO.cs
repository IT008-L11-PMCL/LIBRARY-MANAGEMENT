
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY.DataClass;

namespace LIBRARY.DAO
{
    class viTri_DAO:dataProvider
    {
        public void delete(string maVT)
        {
            string sqlCommand = "delete from VITRI where MaVT = '" + maVT + "'";
            Excute(sqlCommand);
        }
        public void update(viTri t)
        {
            string sqlCommand = string.Format("update VITRI set Khu = '{0}', Ke = '{1}', Ngan = '{2}' where MaVT = '{3}'", t.khu, t.ke, t.ngan, t.maVT);
            Excute(sqlCommand);
        }
        public DataTable search(string s, string tuKhoa)
        {
            string sqlCommmand = string.Format("select * from VITRI where {0} like '%{1}%'", s, tuKhoa);
            return dataTable(sqlCommmand);
        }
        public bool insert(viTri t)
        {
            if (dataTable("select * from VITRI where MaVT ='" + t.maVT + "'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into VITRI values ('{0}','{1}','{2}','{3}')", t.maVT, t.khu, t.ke, t.ngan);
            Excute(sqlCommand);
            return true;
        }
        public DataTable loadVT()
        {
            string sqlCommand = "select * from VITRI";
            return dataTable(sqlCommand);
        }
    }
}
