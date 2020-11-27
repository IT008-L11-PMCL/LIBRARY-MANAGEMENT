
using DevExpress.XtraBars.Ribbon;
using System;
using System.Linq;
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
            AddChild(bookManagement);
        }

        private void PublishingCompanyForm_Click(object sender, EventArgs e)
        {
            PubCompany pubCompany = new PubCompany();
            AddChild(pubCompany);
        }

        private void Authors_Click(object sender, EventArgs e)
        {
            
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

        private void galleryDropDown1_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            string tag = ((GalleryItem)e.Item).Tag.ToString();
            switch (tag)
            {
                case "profile":
                    break;
                case "signin":
                    break;
                case "register":
                    break;
                case "logout":
                    break;
                case "close":
                    Application.Exit();
                    break;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        { 
        }
    }
}
