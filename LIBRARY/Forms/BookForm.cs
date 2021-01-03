using System;
using LIBRARY.BUSS;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010;
using LIBRARY.DataClass;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

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
        string fileName;
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
            //BookID.Focus();
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
            BookID.Text = dataGridView1.Rows.Count.ToString("0000");

            State.SelectedIndex = 0;
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
                case "export":
                    Export(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void Export(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.Title = "To Excel";
            saveFileDialog.FileName = "book_report.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;

                progressPanel1.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void Insert(object sender, EventArgs e)
        {
            try
            {
                sach s = new sach();             
                s.maSach = BookID.Text;
                s.tenSach = BookTitle.Text;
                s.namXB = DatePublic.Value.ToString();
                s.maXB = PubID.SelectedValue.ToString();
                s.maTG = AuthorID.SelectedValue.ToString();
                s.maTL = BCategoryID.SelectedValue.ToString();
                s.maVT = LocationID.SelectedValue.ToString();
                s.tinhTrang = State.SelectedItem.ToString();
                s.ngonNgu = LanguageID.SelectedValue.ToString();
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
                            
                        }
                    BookForm_Load(sender, e);
                    resetText();
                }
                else
                {
                    toolTip1.ToolTipTitle = "Warning";
                    toolTip1.Show("Select the rows you want to delete!", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Book's using!! Can't delete!! ", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    PubID.SelectedValue = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    AuthorID.SelectedValue = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    BCategoryID.SelectedValue = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    LocationID.SelectedValue = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    State.SelectedValue = dataGridView1.Rows[i].Cells[7].Value;
                    LanguageID.SelectedValue = dataGridView1.Rows[i].Cells[8].Value.ToString();
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
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialog = MessageBox.Show("Data may be lost. Are you sure you want to exit Books??", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string str = textEdit1.Text;
            if (!string.IsNullOrWhiteSpace(str))
                dataGridView1.DataSource = sach.timkiem(str);
            else
                dataGridView1.DataSource = sach.getList();
            dataGridView1.AutoResizeColumns();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            { int columnCount = dataGridView1.ColumnCount;
                object[] columnHeader = new object[columnCount];
                for (int i = 0; i < columnCount; i++)
                    columnHeader[i] = dataGridView1.Columns[i].HeaderText.ToString();
                new ExcelExport().Export(sach.getList(),"LIST OF BOOKS",columnHeader, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops");
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressPanel1.Visible = false;
        }
        private void AuthorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (BookID.Text.Length > 9)
                e.Handled = true;
            if (e.KeyChar.ToString() == "\b")
                e.Handled = false;
            if (e.Handled)
            {
                toolTip1.ToolTipTitle = "Warning";
                toolTip1.Show("ID length more than 10 character", BookID, BookID.Location, 5000);
            }
        }

    }
}

    
