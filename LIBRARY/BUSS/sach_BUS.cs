
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
        public bool them(sach s)
        {
            return sach.insert(s);
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
