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
    public partial class Location : DevExpress.XtraEditors.XtraForm
    {
        viTri_BUS vt = new viTri_BUS();
        public Location()
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

        private void Location_Load(object sender, EventArgs e)
        {
            resetText();
            LocationID.Focus();
            dataGridView1.DataSource = vt.getList();
            dataGridView1.AutoResizeColumns();
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "refresh":
                    Location_Load(sender, e);
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
                viTri v = new viTri();
                v.maVT = LocationID.Text;
                v.khu = Zone.Text;
                v.ke = Shelf.Text;
                v.ngan = Cell.Text;               
                
                    if (vt.them(v))
                    {
                        Location_Load(sender, e);
                        resetText();
                    }
                    else
                    {
                        if (vt.sua(v))
                        {
                            Location_Load(sender, e);
                            resetText();
                        }
                        else return;

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
                            vt.xoa(dataGridView1.Rows[row.Index].Cells[0].Value.ToString());
                            
                        }
                    Location_Load(sender, e);
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
                    LocationID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    Zone.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    Shelf.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    Cell.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();

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
            DialogResult dialog = MessageBox.Show("Data may be lost. Are you sure you want to exit??", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}