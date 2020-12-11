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
            string sqlCommand1 = "delete from CTMT where MaMuon = '" + maMuonTra + "'";
            string sqlCommand = "delete from MUONTRA where MaMuon = '" + maMuonTra + "'";
            Excute(sqlCommand1);
            Excute(sqlCommand);
        }
        public void delete(string maMuon, string maSach)
        {
            string sqlCommand = "delete from CTMT where MaMuon = '" + maMuon + "' and MaSach = '" + maSach + "'";
            Excute(sqlCommand);

        }

        public void update(muonTra muon)
        {
            string sqlCommand = string.Format("update MUONTRA set MaThe = '{0}', MaNV = '{1}', NgayMuon = '{2}', NgayHan = '{3}'  where MaMuon = '{4}' ",muon.maThe,muon.maNV,muon.ngayMuon,muon.ngayHan,muon.maMuon);
            Excute(sqlCommand);
        }
        public void update(string maMuon, string maSach)
        {
            string sqlCommand = string.Format("update CTMT set NgayTra = '{0}', TrangThai = {1}, GhiChu = N'{2}'  where MaMuon = '{3}' and MaSach = '{4}' ", DateTime.Now.ToString(), 1, "Đã trả", maMuon, maSach);
            Excute(sqlCommand);
        }       

        public DataTable search(string maMuon,string maSach)
        {
            string sqlCommmand = string.Format("select * from MUONTRA where MaMuon like '%{0}%' or MaSach like '%{1}%'", maMuon, maSach);
            return dataTable(sqlCommmand);
        }
        public DataTable search(string s)
        {
            string sqlCommmand = string.Format("select * from MUONTRA where MaMuon = '{0}'", s);
            return dataTable(sqlCommmand);

        }

        public DataTable searchCT(string s, string tuKhoa)
        {
            string sqlCommmand = string.Format("select * from CTMT where {0} like '%{1}%'", s, tuKhoa);
            return dataTable(sqlCommmand);
        }
        public DataTable searchCT(string s)
        {
            string sqlCommmand = string.Format("select * from CTMT where MaMuon = '{0}'", s);
            return dataTable(sqlCommmand);
        }

        public bool insert(muonTra muon)
        {
            if (dataTable("select * from MUONTRA where MaMuon ='" + muon.maMuon + "'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into MUONTRA values ('{0}','{1}','{2}','{3}','{4}')", muon.maMuon, muon.maThe,muon.maNV, muon.ngayMuon, muon.ngayHan); 
            Excute(sqlCommand);
            return true;
        }
        public bool insertp(muonTra muon)
        {
            if (dataTable("select * from CTMT where MaMuon ='" + muon.maMuon + "' and MaSach = '"+muon.maSach+"'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into CTMT (MaMuon, MaSach, TrangThai, GhiChu) values ('{0}','{1}','{2}',N'{3}')", muon.maMuon, muon.maSach, muon.trangThai, muon.ghiChu);
            Excute(sqlCommand);
            return true;
        }

        public DataTable loadMuonTra()
        {
            string sqlCommand = "select * from MUONTRA";
            return dataTable(sqlCommand);
        }
        public DataTable loadCTMT(string str) 
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                string sqlCommand = "select * from CTMT";
                return dataTable(sqlCommand);
            }
            else
            {
                string sqlcommand = "select * from CTMT where MaMuon = '" + str + "'";
                return dataTable(sqlcommand);
            }    
        }
    }
}
