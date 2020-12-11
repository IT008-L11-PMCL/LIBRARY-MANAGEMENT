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
        public bool them(muonTra m)
        {
            return muon.insert(m);
        }
        public bool themp(muonTra m)
        {
            return muon.insertp(m);
        }

        public void xoa(string maMuon)
        {
            muon.delete(maMuon);
        }
        public bool sua(muonTra m)
        {
            if (string.IsNullOrEmpty(m.maMuon))
                return false;
            muon.update(m);
            return true;
        }
        public void suaMT(string maMuon, string maSach)
        {
            muon.update(maMuon, maSach);
        }

        public DataTable timkiem(string str)
        {
            return muon.search(str);
        }
        public DataTable timkiem(string maMuon, string maSach)
        {
            return muon.search(maMuon, maSach);
        }

        public DataTable getCTMTList(string str)
        {
            return muon.loadCTMT(str);
        }
        
    }
}
