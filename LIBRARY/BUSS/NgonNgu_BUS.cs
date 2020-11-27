
using System.Data;
using LIBRARY.DAO;
using LIBRARY.DataClass;

namespace LIBRARY.BUSS
{
    class NgonNgu_BUS
    {
        NgonNgu_DAO ngonNgu = new NgonNgu_DAO();
        public DataTable getList()
        {
            return ngonNgu.loadNN();
        }
        public bool them(NgonNgu n)
        {
            return ngonNgu.insert(n);
        }
        public void xoa(string str)
        {
            ngonNgu.delete(str);
        }
        public bool sua(NgonNgu n)
        {
            if (string.IsNullOrEmpty(n.maNN))
                return false;
            ngonNgu.update(n);
            return true;
        }
        public DataTable timkiem(string s, string tk)
        {
            return ngonNgu.search(s, tk);
        }
    }
}
