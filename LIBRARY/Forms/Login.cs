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
using LIBRARY.DataClass;

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
      
        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch(tag)
            {
                case "ok":
                    Ok();
                    break;
                case "register":                   
                    new Registration().ShowDialog();                       
                    break;
            }    
        }

        private void Ok()
        {
            string uName = userName.Text;
            string pWord = passWord.Text;
            if (nv.check(uName, pWord))
            {                
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.user = uName;
                mainForm.ShowDialog();
    
            }
            else
            {
                MessageBox.Show("Wrong password", "Oops", MessageBoxButtons.OK);
                passWord.ResetText();
            }
                
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Ok();    
        }
    }
}