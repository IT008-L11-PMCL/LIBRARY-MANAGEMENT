
using System.Data;
using LIBRARY.DAO;
using LIBRARY.DataClass;

namespace LIBRARY.BUSS
{
    class viTri_BUS
    {
        viTri_DAO vt = new viTri_DAO();
        public DataTable getList()
        {
            return vt.loadVT();
        }
        public int them(viTri t)
        {
            if (string.IsNullOrEmpty(t.maVT))
                return 0;
            if (!vt.insert(t))
                return -1;
            return 1;
        }
        public void xoa(viTri t)
        {
            vt.delete(t.maVT);
        }
        public bool sua(viTri t)
        {
            if (string.IsNullOrEmpty(t.maVT))
                return false;
            vt.update(t);
            return true;
        }
        public DataTable timkiem(string s, string tk)
        {
            return vt.search(s, tk);
        }
    }
}
