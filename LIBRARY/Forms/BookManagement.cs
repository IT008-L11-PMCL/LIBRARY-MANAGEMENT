﻿using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LIBRARY.BUSS;
using LIBRARY.DataClass;
using DevExpress.XtraBars.Docking2010;
using System.Threading;

namespace LIBRARY.Forms
{
    public partial class BookManagement : DevExpress.XtraEditors.XtraForm
    {
        muonTra_BUS muonTra = new muonTra_BUS();
        sach_BUS sach = new sach_BUS();
        TheTV_BUS the = new TheTV_BUS();
        nhanVien_BUS nhanVien = new nhanVien_BUS();
        BookLending bookLending = new BookLending();
        public string user = "";
        protected string fileName = "";
        public BookManagement()
        {
            InitializeComponent();
        }
        private void resetText()
        {
            foreach (Control control in layoutControl1.Controls)
            {
                if (control is TextEdit || control is DateTimePicker)
                    control.ResetText();
            }
        }

        private void BookManagement_Load(object sender, EventArgs e)
        {
            resetText();
            checkedListBoxControl1.Hide();
            bookLending.Hide();
            ID.Focus();
            
            IDCard.DataSource = the.getListUsing();

            IDManager.Text = user;
            IDManager.Enabled = false;

            checkedListBoxControl1.DataSource = sach.getListAvailable();

            //foreach(DataRow row in muonTra.getList().Rows)
            //{
            //    DateTime dateTime = DateTime.Parse(row["NgayHan"].ToString());
            //    TimeSpan timeSpan = DateTime.Now - dateTime;
            //    if (timeSpan.Days >= 60)
            //    {
            //        foreach (DataRow r in muonTra.getCTMTList(row["MaMuon"].ToString()).Rows)
            //        {
            //            sach.capNhatTrangThai(r["MaSach"].ToString(), "Mất");
            //        }

            //    }    
                    
            //}     
            dataGridView1.DataSource = muonTra.getList();
            ID.Text = dataGridView1.Rows.Count.ToString("0000");
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
                case "export":
                    Export(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void Insert(object sender, EventArgs e)
        {
            try
            {
                muonTra mt = new muonTra();
                mt.maMuon = ID.Text;
                mt.ngayMuon = BorrowingDate.Value.ToString();
                mt.ngayHan = DueDate.Value.ToString();
                mt.maThe = IDCard.SelectedValue.ToString();
                mt.maNV = IDManager.Text;
                if (mt.isNull()||checkedListBoxControl1.CheckedItems.Count<=0)
                {
                    toolTip1.ToolTipTitle = "Warning";
                    toolTip1.Show("Please enter full information", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
                    return;
                }
                else
                {
                    if (muonTra.them(mt))
                    {
                        foreach(int itemIndex in checkedListBoxControl1.CheckedIndices)
                        {
                            mt.maSach = checkedListBoxControl1.GetItemValue(itemIndex).ToString();
                            if(muonTra.themp(mt))
                               sach.capNhatTrangThai(mt.maSach, "Đã mượn");
                        }

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
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            muonTra.xoa(dataGridView1.Rows[row.Index].Cells[0].Value.ToString());
                           
                        }
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
                    BorrowingDate.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    DueDate.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    IDCard.SelectedItem = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    IDManager.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                }
                else
                    return;
            }
            catch /*(/*Exception exc)*/
            {
                //MessageBox.Show(exc.Message, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ReaderForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialog = MessageBox.Show("Data may be lost. Are you sure you want to exit Book Management Window??", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void BorrowingDate_ValueChanged(object sender, EventArgs e)
        {
            DueDate.MinDate = BorrowingDate.Value;
            DueDate.Value = BorrowingDate.Value.AddMonths(1);
        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkButton1.Checked == false)
                checkedListBoxControl1.Hide();
            else
            {
                checkedListBoxControl1.Show();
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        { 
            bookLending.Load += BookLending_Load;
            bookLending.windowsUIButtonPanel1.ButtonClick += windowsUIButtonPanel_ButtonClick;
            bookLending.ShowDialog();
        }

        private void BookLending_Load(object sender, EventArgs e)
        {       
           bookLending.dataGridView2.DataSource = muonTra.getCTMTList(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }
        private void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "refresh":
                    BookLending_Load(sender, e);
                    break;
                case "close":
                    bookLending.Hide();
                    break;
                case "return":
                    Return(sender, e);
                    BookLending_Load(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void Export(object sender,EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "docx files (*.docx)|*.docx|All files (*.*)|*.*";
                saveFileDialog.Title = "To Word";
                saveFileDialog.FileName = "reader_report.docx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;

                    progressPanel1.Size = new System.Drawing.Size(236, 54);
                    progressPanel1.Visible = true;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
               
        }

        private void Return(object sender, EventArgs e)
        {
            if (bookLending.dataGridView2.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in bookLending.dataGridView2.SelectedRows)
                {
                    string muonID = row.Cells[0].Value.ToString();
                    string sachID = row.Cells[1].Value.ToString();
                    muonTra.suaMT(muonID, sachID);
                    sach.capNhatTrangThai(sachID, "Có sẵn");
                }
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string str = textEdit1.Text.ToString();
            if (string.IsNullOrWhiteSpace(str))
                dataGridView1.DataSource = muonTra.getList();
            else
                dataGridView1.DataSource = muonTra.timkiem(str);
            dataGridView1.AutoResizeColumns();
        }

        private void ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ID.Text.Length > 9)
                e.Handled = true;
            if (e.KeyChar.ToString() == "\b")
                e.Handled = false;
            if (e.Handled)
            {
                toolTip1.ToolTipTitle = "Warning";
                toolTip1.Show("ID length more than 10 character", ID, ID.Location, 5000);
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string maMuon = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string ngayMuon = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string maThe = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                DataRow DG = new docGia_BUS().timkiem("MaThe", maThe).Rows[0];
                string MaDG = DG["MaDG"].ToString();
                string tenDG = DG["TenDG"].ToString();
                string[] arr = new string[5];
                new Word().createLendingForm(fileName, maMuon, ngayMuon, MaDG, tenDG, maThe);
            }
            catch
            {
                return;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressPanel1.Visible = false;
        }

        private void checkedListBoxControl1_MouseLeave(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            checkButton1.Checked = false;
        }

        private void checkedListBoxControl1_ItemChecking(object sender, DevExpress.XtraEditors.Controls.ItemCheckingEventArgs e)
        {
            if (checkedListBoxControl1.CheckedItemsCount >= 5 && e.NewValue != CheckState.Unchecked)
                e.Cancel = true;
            if(e.Cancel == true)
            {
                toolTip1.ToolTipTitle = "Warning";
                toolTip1.Show("Maximum 5 books", checkedListBoxControl1, checkedListBoxControl1.Location, 5000);
            }    
        }
    }
}