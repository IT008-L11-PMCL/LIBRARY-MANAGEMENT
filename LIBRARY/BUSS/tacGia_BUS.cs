
using System.Data;
using LIBRARY.DAO;
using LIBRARY.DataClass;

namespace LIBRARY.BUSS
{
    class tacGia_BUS
    {
        tacGia_DAO tg = new tacGia_DAO();
        public DataTable getList()
        {
            return tg.loadTG();
        }
        public int them(tacGia t)
        {
            if (string.IsNullOrEmpty(t.maTG))
                return 0;
            if (!tg.insert(t))
                return -1;
            return 1;
        }
        public void xoa(string str)
        {
            tg.delete(str);
        }
        public bool sua(tacGia t)
        {
            if (string.IsNullOrEmpty(t.maTG))
                return false;
            tg.update(t);
            return true;
        }
        public DataTable timkiem(string s, string tk)
        {
            return tg.search(s, tk);
        }
    }
}
