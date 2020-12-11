using System;
using LIBRARY.BUSS;
using LIBRARY.DataClass;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010;

namespace LIBRARY.Forms
{
    public partial class Registration : DevExpress.XtraEditors.XtraForm
    {
        nhanVien_BUS nv = new nhanVien_BUS();
        public Registration()
        {
            InitializeComponent();
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch(tag)
            {
                case "back":                    
                    this.Close();
                    break;
                case "ok":
                    Ok(sender, e);
                    break;
                default:
                    break;
            }    
        }

        private void Ok(object sender, EventArgs e)
        {
            try
            {
                nhanVien n = new nhanVien();
                if (nv.timkiem("UserName", UserName.Text).Rows.Count > 0)
                    MessageBox.Show("User already exists");
                else
                {
                    if (PassWord.Text == Retype.Text)
                    {
                        n.maNV = UserName.Text;
                        n.hoTen = fullName.Text;
                        n.ngaySinh = BirthDay.Value.ToShortDateString();
                        n.sdt = PhoneNumber.Text;
                        n.passWord = PassWord.Text;
                        if(n.isNull())
                        {
                            toolTip1.ToolTipTitle = "Warning";
                            toolTip1.Show("Enter full infomation", Retype, Retype.Location, 5000);

                        }
                        else if (nv.them(n))
                            if (nv.themUser(n))
                            {
                                MessageBox.Show("Done");
                                this.Close();
                            }
                    }
                    else
                    {
                        toolTip1.ToolTipTitle = "Warning";
                        toolTip1.Show("Rytype incorrectly", Retype, Retype.Location, 5000);
                    }
                    
                }
            }
            catch
            {
                MessageBox.Show("Failed", "Oops", MessageBoxButtons.OK);
            }
        }

        private void Registration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\n")
                Ok(sender, e);
        }
    }
}