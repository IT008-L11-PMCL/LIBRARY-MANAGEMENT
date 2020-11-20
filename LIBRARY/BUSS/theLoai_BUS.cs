using System.Data;
using LIBRARY.DAO;
using LIBRARY.DataClass;

namespace LIBRARY.BUSS
{
    class theLoai_BUS
    {
        theLoai_DAO tl = new theLoai_DAO();
        public DataTable getList()
        {
            return tl.loadTL();
        }
        public int them(theLoai t)
        {
            if (string.IsNullOrEmpty(t.maTL))
                return 0;
            if (!tl.insert(t))
                return -1;
            return 1;
        }
        public void xoa(theLoai t)
        {
            tl.delete(t.maTL);
        }
        public bool sua(theLoai t)
        {
            if (string.IsNullOrEmpty(t.maTL))
                return false;
            tl.update(t);
            return true;
        }
        public DataTable timkiem(string s, string tk)
        {
            return tl.search(s, tk);
        }
    }
}
