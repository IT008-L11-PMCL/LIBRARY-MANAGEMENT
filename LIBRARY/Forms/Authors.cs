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
    public partial class Authors : DevExpress.XtraEditors.XtraForm
    {
        tacGia_BUS tacGia = new tacGia_BUS();
        protected string fileName = "";
        public Authors()
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

        private void Authors_Load(object sender, EventArgs e)
        {
            resetText();
            AuthorID.Focus();
            dataGridView1.DataSource = tacGia.getList();
            AuthorID.Text = (dataGridView1.Rows.Count).ToString("000");

            dataGridView1.AutoResizeColumns();
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "refresh":
                    Authors_Load(sender, e);
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
                tacGia tg = new tacGia();
                tg.maTG = AuthorID.Text;
                tg.tenTG = AuthorName.Text;
                tg.website = Website.Text;
                tg.ghiChu = Note.Text;
                if (tg.isNull())
                {
                    toolTip1.ToolTipTitle = "Warning";
                    toolTip1.Show("Please enter full information", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
                    return;
                }
                else
                {
                    if (tacGia.them(tg))
                    {
                        Authors_Load(sender, e);
                        resetText();
                    }
                    else
                    {
                        if (tacGia.sua(tg))
                        {
                            Authors_Load(sender, e);
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
                            tacGia.xoa(dataGridView1.Rows[row.Index].Cells[0].Value.ToString());

                        }
                    Authors_Load(sender, e);
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
                    AuthorID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    AuthorName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    Website.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    Note.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                }
                else
                    return;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Authors_FormClosing(object sender, FormClosingEventArgs e)
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
                dataGridView1.DataSource = tacGia.timkiem("TenTG", str);
            else
                dataGridView1.DataSource = tacGia.getList();
            dataGridView1.AutoResizeColumns();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                int columnCount = dataGridView1.ColumnCount;
                object[] columnHeader = new object[columnCount];
                for (int i = 0; i < columnCount; i++)
                    columnHeader[i] = dataGridView1.Columns[i].HeaderText.ToString();
                new ExcelExport().Export(tacGia.getList(), "LIST OF AUTHORS", columnHeader, fileName);
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

        private void AuthorID_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void AuthorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (AuthorID.Text.Length > 9)
                e.Handled = true;
            if (e.KeyChar.ToString() == "\b")
                e.Handled = false;
            if (e.Handled)
            {
                toolTip1.ToolTipTitle = "Warning";
                toolTip1.Show("ID length more than 10 character",AuthorID,AuthorID.Location,5000);
            }    
        }
    }
}
