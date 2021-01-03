
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
        public DataTable getListAvailable()
        {
            return sach.loadSachCoSan();
        }
        public DataTable getListBeingBorrowed()
        {
            return sach.loadSachDaMuon();
        }
        public DataTable getListBeingDisplayed()
        {
            return sach.loadSachTrungBay();
        }
        public DataTable getListLost()
        {
            return sach.loadSachMat();
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
        public DataTable timkiem(string tk)
        {
            return sach.search(tk);
        }       

        public void capNhatTrangThai(string str, string b)
        {
            sach.updateStatus(str, b);
        }

        public int tongSach()
        {
            return sach.total();
        }

        public int coSan()
        {
            return sach.available();
        }

        public int daMuon()
        {
            return sach.borrowing();
        }

        public int trungBay()
        {
            return sach.display();
        }

        public int mat()
        {
            return sach.lost();
        }
    }
}
