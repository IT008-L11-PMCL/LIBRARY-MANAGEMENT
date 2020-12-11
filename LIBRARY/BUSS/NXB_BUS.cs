
using System.Data;
using LIBRARY.DAO;
using LIBRARY.DataClass;

namespace LIBRARY.BUSS
{
    class NXB_BUS
    {
        NXB_DAO nxb = new NXB_DAO();
        public DataTable getList()
        {
            return nxb.loadNXB();
        }
        public bool them(NXB n)
        {
            return nxb.insert(n);
        }
        public void xoa(string str)
        {
            nxb.delete(str);
        }
        public bool sua(NXB n)
        {
            if (string.IsNullOrEmpty(n.maNXB))
                return false;
            nxb.update(n);
            return true;
        }
        public DataTable timkiem(string s, string tk)
        {
            return nxb.search(s, tk);
        }

       
    }
}
