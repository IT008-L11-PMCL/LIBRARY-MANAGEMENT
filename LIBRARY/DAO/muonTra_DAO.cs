using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LIBRARY.DataClass;

namespace LIBRARY.DAO
{
    class muonTra_DAO:dataProvider
    {
        public void delete(string maMuonTra)
        {
            string sqlCommand = "delete from MUONTRA where MaMuon = '" + maMuonTra + "'";
            Excute(sqlCommand);
        }
        public void update(muonTra muon)
        {
            string sqlCommand = string.Format("update MUONTRA set MaSach = '{0}', HinhThucMuon = '{1}', NgayMuon = {2}, NgayTra = '{3}', SoNgayMuon = {4},MaThe = '{5}', MaNV ='{6}' where MaMuon = '{7}' ", muon.maSach, muon.hinhThuc, muon.ngayMuon, muon.ngayTra, muon.soNgayMuon, muon.maThe, muon.maNV, muon.maMuon);
            Excute(sqlCommand);
        }
        public DataTable search(string s, string tuKhoa)
        {
            string sqlCommmand = string.Format("select * from MUONTRA where {0} like '%{1}%'", s, tuKhoa);
            return dataTable(sqlCommmand);
        }
        public bool insert(muonTra muon)
        {
            if (dataTable("select * from MUONTRA where MaMuon ='" + muon.maMuon + "'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into MUONTRA values ('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}')", muon.maMuon, muon.maSach,muon.hinhThuc, muon.ngayMuon, muon.ngayTra, muon.soNgayMuon, muon.maThe, muon.maNV); 
            Excute(sqlCommand);
            return true;
        }
        public DataTable loadMuonTra()
        {
            string sqlCommand = "select * from MUONTRA";
            return dataTable(sqlCommand);
        }
    }
}
