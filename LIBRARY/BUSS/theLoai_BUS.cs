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
        public bool them(theLoai t)
        {
            return tl.insert(t);
        }
        public void xoa(string str)
        {
            tl.delete(str);
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
