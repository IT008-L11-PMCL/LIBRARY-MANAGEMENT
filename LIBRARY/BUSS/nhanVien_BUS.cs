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
        public int them(nhanVien n)
        {
            if (string.IsNullOrEmpty(n.maNV))
                return 0;
            if (!nv.insert(n))
                return -1;
            return 1;
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
    }
}
