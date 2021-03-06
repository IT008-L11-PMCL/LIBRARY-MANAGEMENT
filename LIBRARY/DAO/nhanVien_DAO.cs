﻿
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY.DataClass;

namespace LIBRARY.DAO
{
    class nhanVien_DAO:dataProvider
    {
        public void delete(string UserName)
        {
            string sqlCommand = "delete from NHANVIEN where UserName = '" + UserName + "'";
            Excute(sqlCommand);
        }
        public void update(nhanVien n)
        {
            string sqlCommand = string.Format("update NHANVIEN set HoTen = N'{0}', NgaySinh = '{1}', SoDT = '{2}'  where UserName = '{3}'", n.hoTen, n.ngaySinh, n.sdt, n.maNV);
            string sqlCommand1 = string.Format("update USERS set PassWord = '{0}' where UserName = '{1}'", n.passWord, n.maNV);
            Excute(sqlCommand);
            Excute(sqlCommand1);
        }
        public DataTable search(string s, string tuKhoa)
        {
            string sqlCommmand = string.Format("select * from NHANVIEN where {0} like '%{1}%'", s, tuKhoa);
            return dataTable(sqlCommmand);
        }
        public bool insert(nhanVien n)
        {
            if (dataTable("select * from NHANVIEN where UserName ='" + n.maNV + "'").Rows.Count > 0)
                return false;
            string sqlCommand = string.Format("insert into NHANVIEN values ('{0}',N'{1}','{2}','{3}')", n.maNV, n.hoTen, n.ngaySinh, n.sdt);
            Excute(sqlCommand);
            return true;
        }
        public DataTable loadNV()
        {
            string sqlCommand = "select * from NHANVIEN";
            return dataTable(sqlCommand);
        }
        
        public DataTable checkUser(string userName, string passWord)
        {
            string sqlCommand = "select * from USERS where UserName = '" + userName + "' and PassWord = '" + passWord + "'";
            return dataTable(sqlCommand);
        }

        public bool insertUser(nhanVien n)
        {
            if(dataTable("select * from USERS where UserName ='" + n.maNV + "'").Rows.Count == 1)
                    return false;
            string sqlCommand = string.Format("insert into USERS values ('{0}','{1}')", n.maNV, n.passWord);
            Excute(sqlCommand);
            return true;
        }    
        
        public DataTable detail(string username)
        {
            string sqlCommand = "Select NHANVIEN.UserName, HoTen, NgaySinh, SoDT, PassWord from NHANVIEN,Users where NHANVIEN.UserName = Users.Username and NHANVIEN.username = '" + username + "'";
            return dataTable(sqlCommand);
        }
    }
}
 