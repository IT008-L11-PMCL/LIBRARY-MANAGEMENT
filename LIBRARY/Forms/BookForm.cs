using System;
using LIBRARY.BUSS;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010;
using LIBRARY.DataClass;

namespace LIBRARY.Forms
{
    public partial class Books : DevExpress.XtraEditors.XtraForm
    {
        sach_BUS sach = new sach_BUS();
        NXB_BUS nxb = new NXB_BUS();
        tacGia_BUS tacGia = new tacGia_BUS();
        theLoai_BUS theLoai = new theLoai_BUS();
        viTri_BUS viTri = new viTri_BUS();
        NgonNgu_BUS ngonNgu = new NgonNgu_BUS();
        public Books()
        {
            InitializeComponent();
        }
        
        private void resetText()
        {
            foreach (Control control in layoutControl1.Controls)
            {
                if (control is TextEdit)
                    control.ResetText();
            }
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            resetText();
            BookID.Focus();
            //
            AuthorID.DataSource = tacGia.getList();
            //
            LanguageID.DataSource = ngonNgu.getList();
            //
            PubID.DataSource = nxb.getList();
            //
            BCategoryID.DataSource = theLoai.getList();
            //
            LocationID.DataSource = viTri.getList();

            dataGridView1.DataSource = sach.getList();
            dataGridView1.AutoResizeColumns();
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "refresh":
                    BookForm_Load(sender, e);
                    break;
                case "close":
                    this.Close();
                    break;
                case "delete":
                    Delete(sender, e);
                    break;
                case "insert":
                    Insert(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void Insert(object sender, EventArgs e)
        {
            try
            {
                sach s = new sach();
                s.maSach = BookID.Text;
                s.tenSach = BookTitle.Text;
                s.namXB = DatePublic.Text;
                s.soLuong = int.Parse(Amount.Text);
                s.maXB = PubID.SelectedItem.ToString();
                s.maTL = BCategoryID.SelectedItem.ToString();
                s.maTG = AuthorID.SelectedItem.ToString();
                s.maVT = LocationID.SelectedItem.ToString();
                s.tinhTrang = State.SelectedIndex;
                s.ngonNgu = LanguageID.SelectedItem.ToString();
                if (s.isNull())
                {
                    toolTip1.ToolTipTitle = "Warning";
                    toolTip1.Show("Please enter full information", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
                    return;
                }
                else
                {
                    if (sach.them(s))
                    {
                        BookForm_Load(sender, e);
                        resetText();
                    }
                    else
                    {
                        if (sach.sua(s))
                        {
                            BookForm_Load(sender, e);
                            resetText();
                        }
                        else return;

                    }

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure want to delete this row!!", "Question", MessageBoxButtons.OKCancel);
                    if (dialog == DialogResult.OK)
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            sach.xoa(dataGridView1.Rows[row.Index].Cells[0].Value.ToString());
                            BookForm_Load(sender, e);
                            resetText();
                        }
                }
                else
                {
                    toolTip1.ToolTipTitle = "Warning";
                    toolTip1.Show("Select the rows you want to delete!", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int i = dataGridView1.SelectedRows[0].Index;
                    BookID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    BookTitle.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    DatePublic.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    Amount.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    PubID.SelectedItem = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    AuthorID.SelectedItem = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    BCategoryID.SelectedItem = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    LocationID.SelectedItem = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    //State.SelectedIndex = dataGridView1.Rows[i].Cells[8].Value;
                    LanguageID.SelectedItem = dataGridView1.Rows[i].Cells[9].Value.ToString();
                }
                else
                    return;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Data may be lost. Are you sure want to exit??", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;           
                toolTip1.ToolTipTitle = "Warning";
                toolTip1.Show("Please enter a digit", Amount, Amount.Location, 2000);
            }    
        }
    }
}

    
