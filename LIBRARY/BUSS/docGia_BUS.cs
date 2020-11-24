
using LIBRARY.DataClass;
using LIBRARY.DAO;
using System.Data;

namespace LIBRARY.BUSS
{
    class docGia_BUS
    {
        docGia_DAO dG = new docGia_DAO();
        public DataTable getList()
        {
            return dG.loadDocGia();
        }
        public bool them(docGia d)
        {
            return dG.insert(d);
        }
        public void xoa(string s)
        {
            dG.delete(s);
        }
        public bool sua(docGia d)
        {
            if (string.IsNullOrEmpty(d.maDG))
                return false;
            dG.update(d);
            return true;
        }
        public DataTable timkiem(string s, string tk)
        {
            return dG.search(s, tk);
        }
    }
}
