
using DevExpress.XtraBars.Ribbon;
using System;
using System.Linq;
using System.Windows.Forms;
using LIBRARY.BUSS;

namespace LIBRARY.Forms
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public string user = "";
        public MainForm()
        {
            InitializeComponent();
            this.EnableAcrylicAccent = false;
            // Handling the QueryControl event that will populate all automatically generated Documents
            // Handling the QueryControl event that will populate all automatically generated Documents
            this.tabbedView1.QueryControl += tabbedView1_QueryControl;
        }

        private void Cards_Click(object sender, EventArgs e)
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
            Books bookForm = new Books();
            AddChild(bookForm);
        }

        private void Readers_Click(object sender, EventArgs e)
        {
            Reader reader = new Reader();
            AddChild(reader);
        }

        private void BookManagement_Click(object sender, EventArgs e)
        {
            BookManagement bookManagement = new BookManagement();
            bookManagement.user = user;
            AddChild(bookManagement);
        }

        private void PublishingCompanyForm_Click(object sender, EventArgs e)
        {
            PubCompany pubCompany = new PubCompany();
            AddChild(pubCompany);
        }

        private void Authors_Click(object sender, EventArgs e)
        {
            Authors authors = new Authors();
            AddChild(authors);
        }

        private void Language_Click(object sender, EventArgs e)
        {
            Languages languages = new Languages();
            AddChild(languages);
        }

        private void Categories_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            AddChild(categories);
        }

        private void Location_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            AddChild(location);
        }
        //Profile profile = new Profile();
        //nhanVien_BUS nhanVien = new nhanVien_BUS();
        private void galleryDropDown1_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            string tag = ((GalleryItem)e.Item).Tag.ToString();
            switch (tag)
            {
                case "profile":
                    Profile profile = new Profile();
                    profile.user = this.user;
                    profile.ShowDialog();
                    break;
                case "signin":
                    break;
                case "register":
                    new Registration().ShowDialog();
                    break;
                case "logout":
                    Application.Restart();
                    break;
                case "close":
                    Application.Exit();
                    break;
            }
        }     
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to exit! All data may be lost!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Cancel)
                e.Cancel = true;             
        }

        private void accordionControl1_MouseEnter(object sender, EventArgs e)
        {
            accordionControl1.AnimationType = DevExpress.XtraBars.Navigation.AnimationType.Default;
            accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Normal;
        }

        private void accordionControl1_MouseLeave(object sender, EventArgs e)
        {
            accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
        }

        void tabbedView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            
            if (e.Document == homeDocument)
                e.Control = new LIBRARY.Forms.Home();
     
            if (e.Control == null)
                e.Control = new System.Windows.Forms.Control();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
