using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LIBRARY.BUSS;
using LIBRARY.DataClass;
using DevExpress.XtraBars.Docking2010;

namespace LIBRARY.Forms
{
    public partial class Profile : DevExpress.XtraEditors.XtraForm
    {
        public string user = "";
        nhanVien nv = new nhanVien();
        nhanVien_BUS nhanVien = new nhanVien_BUS();
        public Profile()
        {
            InitializeComponent();
        }
        private void Profile_Load(object sender, EventArgs e)
        {
            if (nhanVien.ChiTiet(user).Rows.Count > 0)
            {
                Fullname.Text = nhanVien.ChiTiet(user).Rows[0]["HoTen"].ToString();
                Birthday.Value = DateTime.Parse(nhanVien.ChiTiet(user).Rows[0]["NgaySinh"].ToString());
                PhoneNumber.Text = nhanVien.ChiTiet(user).Rows[0]["SoDT"].ToString();
                Username.Text = nhanVien.ChiTiet(user).Rows[0]["UserName"].ToString();
                Password.Text = nhanVien.ChiTiet(user).Rows[0]["PassWord"].ToString();
            }
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch(tag)
            {
                case "edit":
                    Edit();
                    break;
                case "close":
                    this.Close();
                    break;
                default:
                    break;
            }    
        }
        private void Edit()
        {
            if (Fullname.Enabled == false)
                foreach (Control control in layoutControl1.Controls)
                {
                    if ((control is TextEdit || control is DateTimePicker)&&control!=Username)
                        control.Enabled = true;
                }
            else
            {
                nv.maNV = Username.Text;
                nv.hoTen = Fullname.Text;
                nv.ngaySinh = Birthday.Value.ToString();
                nv.sdt = PhoneNumber.Text;
                nv.passWord = Password.Text;
                if (nv.isNull())
                {
                    toolTip1.ToolTipTitle = "Warning";
                    toolTip1.Show("Please enter full information", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
                }
                else
                {
                    if (nhanVien.sua(nv))
                    {
                        MessageBox.Show("Update successful", "Infomation");
                        Profile_Load(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Update unsuccesful", "Warning");
                        return;
                    }
                }
            }
        }

        private void PhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) || PhoneNumber.Text.Length > 9)&&e.KeyChar.ToString() != "\b")
                e.Handled = true;
            if(e.Handled)
            {
                toolTip1.ToolTipTitle = "Warning";
                toolTip1.Show("This charater is not a number or Phone number length more than 10 character", PhoneNumber, PhoneNumber.Location, 5000);
            }
        }
    }
}