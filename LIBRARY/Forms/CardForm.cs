﻿using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using LIBRARY.BUSS;
using LIBRARY.DataClass;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace LIBRARY
{
    public partial class CardForm : DevExpress.XtraEditors.XtraForm
    {
        TheTV_BUS the = new TheTV_BUS();
        private string fileName;
        public CardForm()
        {
            InitializeComponent();
        }
        //
        private void resetText()
        {
            foreach (Control control in layoutControl1.Controls)
            {
                if (control is TextEdit || control is DateTimePicker)
                    control.ResetText();
            }    
        }  
             
        private void Form1_Load(object sender, EventArgs e)
        {
            resetText();

            //MessageBox.Show(string.Format("{0}: {1}", dataGridView1.Rows[0].Cells[2].Value.GetType().Name, (dataGridView1.Rows[0].Cells[2].Value == null ? "NULL" : dataGridView1.Rows[0].Cells[2].Value.ToString())));
            if (the.getList().Rows.Count > 0)
                foreach (DataRow row in the.getList().Rows)
                {
                    DateTime dateTime = DateTime.Parse(row["NgayHetHan"].ToString());
                    if (dateTime < DateTime.Now)
                    {
                        string mt = row["MaThe"].ToString();
                        the.capNhatTT(mt, "Hết hạn");
                    }
                }
            progressPanel1.Visible = false;
            CardID.Focus();
            dataGridView1.DataSource = the.getList();
            CardID.Text = dataGridView1.Rows.Count.ToString("0000");
            dataGridView1.AutoResizeColumns();
        }            

        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "refresh":
                    Form1_Load(sender, e);
                    break;
                case "close":
                    this.Close();
                    break;
                case "export":
                    Export(sender, e);
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
            saveFileDialog.FileName = "card_report.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;

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
                new ExcelExport().Export(the.getList(), "LIST OF CARDS", columnHeader, fileName);
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

        public string addCard()
        {
            try
            {
                theTV t = new theTV();
                t.maThe = "CARD" + (the.getList().Rows.Count+1).ToString("0000");
                t.ngayBD = DateTime.Now.ToString(); 
                t.ngayHH = DateTime.Now.AddYears(1).ToString();
                if (the.them(t))
                {
                    return t.maThe;
                }
                else return null;
            }
            catch
            {
                MessageBox.Show("Auto add card unsuccessful", "Oops");
                return null;
            }
        }

        private void Insert(object sender,EventArgs e)
        {
            try
            {
                theTV t = new theTV();
                t.maThe =  CardID.Text;
                t.ngayBD = IDate.Value.ToString();
                t.ngayHH = EDate.Value.ToString();
                if (Note.Text != "")
                    t.ghiChu = Note.Text;
                if (t.isNull())
                {
                    toolTip1.ToolTipTitle = "Warning";
                    toolTip1.Show("Please enter full information", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
                    return;
                }
                else
                {
                    if (the.them(t))
                    {
                        Form1_Load(sender, e);
                        resetText();
                    }
                    else
                    {
                        if (the.sua(t))
                        {
                            Form1_Load(sender, e);
                            resetText();
                        }
                        else return;

                    }

                }
            }
            catch(Exception exc)
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
                            the.xoa(dataGridView1.Rows[row.Index].Cells[0].Value.ToString());                       
                        }
                    Form1_Load(sender, e);
                    resetText();
                }
                else
                {
                    toolTip1.ToolTipTitle = "Warning";
                    toolTip1.Show("Select the rows you want to delete!", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
                }
            }
            catch
            {
                MessageBox.Show("This card's using\nCan't delete!!", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int i = dataGridView1.SelectedRows[0].Index;
                    CardID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    IDate.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    EDate.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    Note.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                }
                else
                    return;
            }
            catch(Exception exc)
            { 
                MessageBox.Show(exc.Message,"Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialog = MessageBox.Show("Data may be lost. Are you sure you want to exit Cards window??", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void IDate_ValueChanged(object sender, EventArgs e)
        {
            EDate.MinDate = IDate.Value;
            EDate.Value = IDate.Value.AddYears(1);
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string str = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(str))
                dataGridView1.DataSource = the.getList();
            else
                dataGridView1.DataSource = the.timkiem("MaThe", str);
            dataGridView1.AutoResizeColumns();
        }

        private void CardID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CardID.Text.Length > 9)
                e.Handled = true;
            if (e.KeyChar.ToString() == "\b")
                e.Handled = false;
            if (e.Handled)
            {
                toolTip1.ToolTipTitle = "Warning";
                toolTip1.Show("ID length more than 10 character", CardID, CardID.Location, 5000);
            }

        }
    }
}
