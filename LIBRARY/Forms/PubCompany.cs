using System;
using LIBRARY.BUSS;
using LIBRARY.DataClass;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010;

namespace LIBRARY.Forms
{
    public partial class PubCompany : DevExpress.XtraEditors.XtraForm
    {
        NXB_BUS nxb = new NXB_BUS();
        protected string fileName = "";
        public PubCompany()
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

        private void PubCompany_Load(object sender, EventArgs e)
        {
            resetText();
            PubName.Focus();
            dataGridView1.DataSource = nxb.getList();
            PCID.Text = dataGridView1.Rows.Count.ToString("0000");
            dataGridView1.AutoResizeColumns();
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "export":
                    Export(sender, e);
                    break;
                case "refresh":
                    PubCompany_Load(sender, e);
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
        private void Export(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.Title = "To Excel";
            saveFileDialog.FileName = "publisher_report.xlsx";

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
                NXB n = new NXB();
                n.maNXB = PCID.Text;
                n.tenNXB = PubName.Text;
                n.diaChi = Address.Text;
                n.email = Email.Text;
                n.thongTin = Infomation.Text;
                if (n.isNull())
                {
                    toolTip1.ToolTipTitle = "Warning";
                    toolTip1.Show("Please enter full information", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
                }
                else
                {
                    if (nxb.them(n))
                    {
                        PubCompany_Load(sender, e);
                        resetText();
                    }
                    else
                    {
                        if (nxb.sua(n))
                        {
                            PubCompany_Load(sender, e);
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
                            nxb.xoa(dataGridView1.Rows[row.Index].Cells[0].Value.ToString());

                        }
                    PubCompany_Load(sender, e);
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
                    PCID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    PubName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    Address.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    Email.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    Infomation.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();

                }
                else
                    return;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PubCompany_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialog = MessageBox.Show("Data may be lost. Are you sure you want to exit??", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string str = textEdit1.Text;
            if (!string.IsNullOrWhiteSpace(str))
                dataGridView1.DataSource = nxb.timkiem("TenNXB", str);
            else
                dataGridView1.DataSource = nxb.getList();
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
                new ExcelExport().Export(nxb.getList(), "LIST OF PUBLISHERS", columnHeader, fileName);
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

        private void PCID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (PCID.Text.Length > 9)
                e.Handled = true;
            if (e.KeyChar.ToString() == "\b")
                e.Handled = false;
            if (e.Handled)
            {
                toolTip1.ToolTipTitle = "Warning";
                toolTip1.Show("ID length more than 10 character", PCID, PCID.Location, 5000);
            }

        }
    }
}