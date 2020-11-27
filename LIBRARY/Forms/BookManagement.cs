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
    public partial class BookManagement : DevExpress.XtraEditors.XtraForm
    {
        muonTra_BUS muonTra = new muonTra_BUS();
        sach_BUS sach = new sach_BUS();
        TheTV_BUS the = new TheTV_BUS();
        nhanVien_BUS nhanVien = new nhanVien_BUS();
        public BookManagement()
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

        private void BookManagement_Load(object sender, EventArgs e)
        {
            resetText();
            ID.Focus();
            //
            CardID.DataSource = the.getList();
            BookID.DataSource = sach.getList();
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if ((DateTime)row.Cells[4].Value > DateTime.Now)
            //        row.DefaultCellStyle.BackColor = Color.Red;
            //}
                
            dataGridView1.DataSource = muonTra.getList();
            dataGridView1.AutoResizeColumns();
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "refresh":
                    BookManagement_Load(sender, e);
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
                case "extend":
                    Extend(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void Extend(object sender,EventArgs e)
        {
           
        }

        private void Insert(object sender, EventArgs e)
        {
            try
            {
                muonTra mt = new muonTra();
                mt.maMuon = ID.Text;
                mt.maSach = BookID.SelectedItem.ToString();
                mt.ngayMuon = BorrowingDate.Value.ToString();
                mt.ngayTra = ReturnDate.Value.ToString();
                mt.soNgayMuon = (BorrowingDate.Value - ReturnDate.Value).Days;
                mt.hinhThuc = comboBox3.SelectedItem.ToString();
                mt.maThe = CardID.SelectedItem.ToString();
                mt.maNV = ManagerID.SelectedItem.ToString();
                if (mt.isNull())
                {
                    toolTip1.ToolTipTitle = "Warning";
                    toolTip1.Show("Please enter full information", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
                    return;
                }
                else
                {
                    if (muonTra.them(mt))
                    {
                        BookManagement_Load(sender, e);
                        resetText();
                    }
                    else
                    {
                        if (muonTra.sua(mt))
                        {
                            BookManagement_Load(sender, e);
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
                            muonTra.xoa(dataGridView1.Rows[row.Index].Cells[0].Value.ToString());
                            BookManagement_Load(sender, e);
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
                    ID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    BookID.SelectedItem = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    comboBox3.SelectedItem = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    BorrowingDate.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    ReturnDate.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    CardID.SelectedItem = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    ManagerID.SelectedItem = dataGridView1.Rows[i].Cells[7].Value.ToString();
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
            DialogResult dialog = MessageBox.Show("Data may be lost. Are you sure you want to exit Book Management Window??", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}