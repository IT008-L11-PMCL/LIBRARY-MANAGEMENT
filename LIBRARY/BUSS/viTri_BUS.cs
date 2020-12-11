
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
        public bool them(viTri t)
        {
            return vt.insert(t);
        }
        public void xoa(string str)
        {
            vt.delete(str);
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
