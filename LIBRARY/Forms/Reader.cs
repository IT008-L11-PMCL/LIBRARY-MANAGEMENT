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
        private string fileName;
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
            CardID.DataSource = the.getListAvai();
            //        
            progressPanel1.Visible = false;
            dataGridView1.DataSource = docGia.getList();
            ReaderID.Text = dataGridView1.Rows.Count.ToString("0000");
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
                case "export":
                    Export(sender, e);
                    break;
                case "print":
                    Print(sender, e);
                    break;
                default:
                    break;
            }
        }
        private void Print(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "docx files (*.docx)|*.docx|All files (*.*)|*.*";
                saveFileDialog.Title = "To Word";
                saveFileDialog.FileName = "card.docx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;

                    progressPanel1.Size = new System.Drawing.Size(132, 54);
                    progressPanel1.Visible = true;
                    backgroundWorker2.RunWorkerAsync();
                }
            }
            else
            {
                toolTip1.ToolTipTitle = "Warning";
                toolTip1.Show("Select the row you want", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
            }                
        }




        private void Export(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.Title = "To Excel";
            saveFileDialog.FileName = "reader_report.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;

                progressPanel1.Size = new System.Drawing.Size(236, 54);
                progressPanel1.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                int columnCount = dataGridView1.ColumnCount;
                object[] columnHeader = new object[columnCount];
                for (int i = 0; i < columnCount; i++)
                    columnHeader[i] = dataGridView1.Columns[i].HeaderText.ToString();
                new ExcelExport().Export(docGia.getList(), "LIST OF READERS", columnHeader, fileName);
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
        private void Insert(object sender, EventArgs e)
        {
            try
            {
                docGia d = new docGia();
                d.maDG = ReaderID.Text;
                d.tenDG = ReaderName.Text;
                d.diaChi = Address.Text;
                if (CardID.SelectedValue == null)
                {
                    string temp = new CardForm().addCard();
                    if (temp == null)
                        throw new Exception("Add card unsuccessful");
                    else d.maThe = temp;
                }
                else { d.maThe = CardID.SelectedValue.ToString(); }
                
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
                        the.capNhatTT(d.maThe, "Đang sử dụng");
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
                        else throw new Exception("Can't insert or update!!");

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
                            the.capNhatTT(dataGridView1.Rows[row.Index].Cells[3].Value.ToString(),"Mới");
                            docGia.xoa(dataGridView1.Rows[row.Index].Cells[0].Value.ToString());
                        }
                    ReaderForm_Load(sender, e);
                    resetText();
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
                    CardID.SelectedValue = dataGridView1.Rows[i].Cells[3].Value.ToString();
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

        private void ReaderID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ReaderID.Text.Length > 9)
                e.Handled = true;
            if (e.KeyChar.ToString() == "\b")
                e.Handled = false;
            if (e.Handled)
            {
                toolTip1.ToolTipTitle = "Warning";
                toolTip1.Show("ID length more than 10 character", ReaderID, ReaderID.Location, 5000);
            }

        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {


            DataGridViewRow row = dataGridView1.SelectedRows[0];
            new Word().createDocument(fileName, row.Cells[1].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[0].Value.ToString());


        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressPanel1.Visible = false;
        }
    }
}