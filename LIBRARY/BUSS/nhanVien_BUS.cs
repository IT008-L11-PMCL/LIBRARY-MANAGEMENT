using System.Data;
using LIBRARY.DAO;
using LIBRARY.DataClass;

namespace LIBRARY.BUSS
{
    class nhanVien_BUS
    {
        nhanVien_DAO nv = new nhanVien_DAO();
        public DataTable getList()
        {
            return nv.loadNV();
        }
        public bool them(nhanVien n)
        {
            return nv.insert(n);
        }
        public void xoa(nhanVien n)
        {
            nv.delete(n.maNV);
        }
        public bool sua(nhanVien n)
        {
            if (string.IsNullOrEmpty(n.maNV))
                return false;
            nv.update(n);
            return true;
        }
        public DataTable timkiem(string s, string tk)
        {
            return nv.search(s, tk);
        }

        public bool check(string userName, string passWord)
        {
            if (nv.checkUser(userName, passWord).Rows.Count > 0)
                return true;
            return false;
        }

        public bool themUser(nhanVien n)
        {
            return nv.insertUser(n);
        }
    }
}
