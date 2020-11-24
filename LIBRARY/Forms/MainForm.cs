using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views.NativeMdi;
using DevExpress.XtraBars.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LIBRARY.Forms
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.EnableAcrylicAccent = false;
        }

        private void accordionControl1_MouseEnter(object sender, EventArgs e)
        {
            accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Normal;
        }

        private void accordionControl1_MouseLeave(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            CardForm cardForm = new CardForm();
            AddChild(cardForm);
        }

       private bool isActive(Form form)
        {
            if (MdiChildren.Count() > 0)
                foreach (var item in MdiChildren)
                    if (form.Name == item.Name)
                        return true;
            return false;
        }

        private void AddChild(object sender)
        {
            Form form = sender as Form;
            if (!isActive(form))
            {
                form.MdiParent = this;
                form.Show();
            }
        }

        private void Books_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm();
            AddChild(bookForm);
        }
    }
}
