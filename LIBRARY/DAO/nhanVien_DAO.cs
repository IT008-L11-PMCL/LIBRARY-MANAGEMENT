
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY.DataClass;

namespace LIBRARY.DAO
{
    class nhanVien_DAO:dataProvider
    {
        public void delete(string maNV)
        {
            string sqlCommand = "delete from NHANVIEN where MaNV = '" + maNV + "'";
            Excute(sqlCommand);
        }
        public void update(nhanVien n)
        {
            string sqlCommand = string.Format("update NHANVIEN set HoTen = '{0}', NgaySinh = '{1}', SoDT = '{2} where MaNV = '{3}'", n.hoTen, n.ngaySinh, n.sdt, n.maNV);
            Excute(sqlCommand);
        }
        public DataTable search(string s, string tuKhoa)
        {
            string sqlCommmand = string.Format("select * from NHANVIEN where {0} like '%{1}%'", s, tuKhoa);
            return dataTable(sqlCommmand);
        }
        public bool insert(nhanVien n)
        {
            if (dataTable("select * from NHANVIEN where MaNV ='" + n.maNV + "'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into NHANVIEN values ('{0}','{1}','{2}','{3}')", n.maNV, n.hoTen, n.ngaySinh, n.sdt);
            Excute(sqlCommand);
            return true;
        }
        public DataTable loadNV()
        {
            string sqlCommand = "select * from NHANVIEN";
            return dataTable(sqlCommand);
        }
    }
}
