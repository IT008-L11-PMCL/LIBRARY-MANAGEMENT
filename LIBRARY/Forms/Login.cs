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
using DevExpress.XtraBars.Docking2010;
using LIBRARY.BUSS;

namespace LIBRARY.Forms
{
    
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        nhanVien_BUS nv = new nhanVien_BUS();
        public Login()
        {
            InitializeComponent();
        }

        private void labelControl2_MouseEnter(object sender, EventArgs e)
        {
            labelControl2.ForeColor = Color.Blue;
        }

        private void labelControl2_MouseLeave(object sender, EventArgs e)
        {
            labelControl2.ForeColor = Color.FromArgb(72, 70, 68);
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            userName.Focus();
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\n")
                Ok(sender, (EventArgs)e);
            else return;

        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch(tag)
            {
                case "ok":
                    Ok(sender, e);
                    break;
                case "register":                   
                    new Registration().ShowDialog();                       
                    break;
            }    
        }

        private void Ok(object sender, EventArgs e)
        {
            string uName = userName.Text;
            string pWord = passWord.Text;
            if (nv.check(uName, pWord))
            {
                this.Hide();
                new MainForm().ShowDialog();
            }
            else
            {
                MessageBox.Show("Login Failed", "Oops", MessageBoxButtons.OK);
            }
                
        }
    }
}