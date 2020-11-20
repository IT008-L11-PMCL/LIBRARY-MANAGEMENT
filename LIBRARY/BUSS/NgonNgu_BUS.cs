
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
        public int them(NgonNgu n)
        {
            if (string.IsNullOrEmpty(n.maNN))
                return 0;
            if (!ngonNgu.insert(n))
                return -1;
            return 1;
        }
        public void xoa(NgonNgu n)
        {
            ngonNgu.delete(n.maNN);
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
