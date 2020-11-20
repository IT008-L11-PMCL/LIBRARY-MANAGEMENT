
using System.Data;
using LIBRARY.DataClass;
using LIBRARY.DAO;


namespace LIBRARY.BUSS
{
    class sach_BUS
    {
        sach_DAO sach = new sach_DAO();
        public DataTable getList()
        {
            return sach.loadSach();
        }
        public int them(sach s)
        {
            if (string.IsNullOrEmpty(s.maSach))
                return 0;
            if (!sach.insert(s))
                return -1;
            return 1;
        }
        public void xoa(string str)
        {
            sach.delete(str);
        } 
        public bool sua(sach s)
        {
            if (string.IsNullOrEmpty(s.maSach))
                return false;
            sach.update(s);
            return true;
        }
        public DataTable timkiem(string s, string tk)
        {
            return sach.search(s, tk);
        }
    }
}
