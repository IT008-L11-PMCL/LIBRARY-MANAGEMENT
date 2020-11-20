using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views.NativeMdi;
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

        void AddChild(object sender)
        {
            Form form = sender as Form;
            form.MdiParent = this;
            form.Show();
            form.BringToFront();
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {

        }

    }
}
