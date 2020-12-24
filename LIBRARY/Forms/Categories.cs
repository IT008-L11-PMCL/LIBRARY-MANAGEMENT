using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using LIBRARY.BUSS;
using LIBRARY.DataClass;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010;

namespace LIBRARY.Forms
{
    public partial class Categories : DevExpress.XtraEditors.XtraForm
    {
        theLoai_BUS tl = new theLoai_BUS();

        public Categories()
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

            private void Categories_Load(object sender, EventArgs e)
            {
                resetText();
                CategoryID.Focus();
                dataGridView1.DataSource = tl.getList();
            CategoryID.Text = dataGridView1.Rows.Count.ToString("00");
                dataGridView1.AutoResizeColumns();
            }

            private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
            {
                string tag = ((WindowsUIButton)e.Button).Tag.ToString();
                switch (tag)
                {
                    case "refresh":
                        Categories_Load(sender, e);
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
                theLoai t = new theLoai();
                t.maTL = CategoryID.Text;
                t.tenTL = CategoryName.Text;
                if (t.isNull())
                {
                    toolTip1.ToolTipTitle = "Warning";
                    toolTip1.Show("Please enter full information", windowsUIButtonPanel1, windowsUIButtonPanel1.Location, 5000);
                    return;
                }
                else
                {
                    if (tl.them(t))
                    {
                        Categories_Load(sender, e);
                        resetText();
                    }
                    else
                    {
                        if (tl.sua(t))
                        {
                            Categories_Load(sender, e);
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
                                tl.xoa(dataGridView1.Rows[row.Index].Cells[0].Value.ToString());
                                Categories_Load(sender, e);
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
                        CategoryID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        CategoryName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
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
                    DialogResult dialog = MessageBox.Show("Data may be lost. Are you sure you want to exit Cards window??", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Cancel)
                        e.Cancel = true;
                }
            }

        private void CategoryID_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}