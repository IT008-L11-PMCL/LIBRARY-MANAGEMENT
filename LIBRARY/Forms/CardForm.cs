using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using LIBRARY.BUSS;
using LIBRARY.DataClass;
using System;
using System.Windows.Forms;

namespace LIBRARY
{
    public partial class CardForm : DevExpress.XtraEditors.XtraForm
    {
        TheTV_BUS the = new TheTV_BUS();
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
            CardID.Focus();
            dataGridView1.DataSource = the.getList();
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
                    Application.Exit();
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

        private void Insert(object sender,EventArgs e)
        {
            try
            {
                theTV t = new theTV();
                t.maThe = CardID.Text;
                t.ngayBD = IDate.Value.ToString();
                t.ngayHH = EDate.Value.ToString();
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
                            Form1_Load(sender, e);
                            resetText();
                        }
                }
                else
                {
                    toolTip1.ToolTipTitle = "Warning";
                    toolTip1.Show("Select the rows you want to delete!", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
                }
            }
            catch(Exception exc)
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
            DialogResult dialog = MessageBox.Show("All data will be lost. Are you sure want to exit??", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}
