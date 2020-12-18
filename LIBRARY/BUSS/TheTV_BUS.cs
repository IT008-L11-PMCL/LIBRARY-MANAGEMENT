using System.Data;
using LIBRARY.DataClass;
using LIBRARY.DAO;

namespace LIBRARY.BUSS
{
    class TheTV_BUS
    {
        theTV_DAO the = new theTV_DAO();
        public DataTable getList()
        {
            return the.loadThe();
        }
        public bool them(theTV t)
        {
            return (the.insert(t));
        }
        public void xoa(string str)
        {
            the.delete(str);
        }
        public bool sua(theTV t)
        {
            if (string.IsNullOrEmpty(t.maThe))
                return false;
            the.update(t);
            return true;
        }
        public DataTable timkiem(string s, string tk)
        {
            return the.search(s, tk);
        }

        public void capNhatTT(string s, string b)
        {
            the.updateStatus(s, b);
        }
    }
}
