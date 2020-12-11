using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LIBRARY.BUSS;
using DevExpress.XtraBars.Docking2010;
using LIBRARY.DataClass;

namespace LIBRARY.Forms
{
    public partial class Reader : DevExpress.XtraEditors.XtraForm
    {
        docGia_BUS docGia = new docGia_BUS();
        TheTV_BUS the = new TheTV_BUS();
        public Reader()
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

        private void ReaderForm_Load(object sender, EventArgs e)
        {
            resetText();
            ReaderID.Focus();
            //
            CardID.DataSource = the.getList();
            //        
            dataGridView1.DataSource = docGia.getList();
            dataGridView1.AutoResizeColumns();
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "refresh":
                    ReaderForm_Load(sender, e);
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
                docGia d = new docGia();
                d.maDG = ReaderID.Text;
                d.tenDG = ReaderName.Text;
                d.diaChi = Address.Text;
                d.maThe = CardID.Text;
                d.ghiChu = Note.Text;
                if (d.isNull())
                {
                    toolTip1.ToolTipTitle = "Warning";
                    toolTip1.Show("Please enter full information", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
                    return;
                }
                else
                {
                    if (docGia.them(d))
                    {
                        ReaderForm_Load(sender, e);
                        resetText();
                    }
                    else
                    {
                        if (docGia.sua(d))
                        {
                            ReaderForm_Load(sender, e);
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
                    DialogResult dialog = MessageBox.Show("Are you sure you want to delete this row!!", "Question", MessageBoxButtons.OKCancel);
                    if (dialog == DialogResult.OK)
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            docGia.xoa(dataGridView1.Rows[row.Index].Cells[0].Value.ToString());
                            ReaderForm_Load(sender, e);
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
                    ReaderID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    ReaderName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    Address.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    CardID.SelectedItem = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    Note.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                }
                else
                    return;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReaderForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialog = MessageBox.Show("Data may be lost. Are you sure you want to exit Readers Window??", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string str = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(str))
                dataGridView1.DataSource = docGia.getList();
            else
                dataGridView1.DataSource = docGia.timkiem("MaDG", str);
            dataGridView1.AutoResizeColumns();
        }
    }
}