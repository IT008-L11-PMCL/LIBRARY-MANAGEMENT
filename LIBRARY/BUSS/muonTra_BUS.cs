using System.Data;
using LIBRARY.DAO;
using LIBRARY.DataClass;

namespace LIBRARY.BUSS
{
    class muonTra_BUS
    {
        muonTra_DAO muon = new muonTra_DAO();
        public DataTable getList()
        {
            return muon.loadMuonTra();
        }
        public int them(muonTra m)
        {
            if (string.IsNullOrEmpty(m.maMuon))
                return 0;
            if (!muon.insert(m))
                return -1;
            return 1;
        }
        public void xoa(muonTra m)
        {
            muon.delete(m.maMuon);
        }
        public bool sua(muonTra m)
        {
            if (string.IsNullOrEmpty(m.maMuon))
                return false;
            muon.update(m);
            return true;
        }
        public DataTable timkiem(string s, string tk)
        {
            return muon.search(s, tk);
        }
    }
}
