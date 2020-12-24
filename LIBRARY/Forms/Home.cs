using System;
using LIBRARY.BUSS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Windows.Forms.DataVisualization.Charting;
using DevExpress.XtraCharts;

namespace LIBRARY.Forms
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        sach_BUS sach = new sach_BUS();
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //chưa cập nhật theo thay đổi

            total.Text = "Total: " + sach.tongSach();
            borrow.Text = "Being borrowed: " + sach.daMuon();
            Available.Text = "Available: " + sach.coSan();
            Display.Text = "Being displayed: " + sach.trungBay();
            Others.Text = "Lost: " + sach.mat();


            chartControl1.Series["Books"].Points.Clear();
            chartControl1.Series["Books"].Points.Add(new SeriesPoint("Available", sach.coSan()));
            chartControl1.Series["Books"].Points.Add(new SeriesPoint("Being borrowed", sach.daMuon()));
            chartControl1.Series["Books"].Points.Add(new SeriesPoint("Being displayed", sach.trungBay()));
            chartControl1.Series["Books"].Points.Add(new SeriesPoint("Lost", sach.mat()));


            dataGridView1.DataSource = sach.getListAvailable();
            //chartControl1.Series["Readers"].Points.Clear();
            //chartControl1.Series["Readers"].Points.Add(new SeriesPoint("Available", sach.coSan()));
            //chartControl1.Series["Readers"].Points.Add(new SeriesPoint("Being borrowed", sach.daMuon()));
            //chartControl1.Series["Readers"].Points.Add(new SeriesPoint("Being displayed", sach.trungBay()));

        }        

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        private void chartControl1_MouseMove(object sender, MouseEventArgs e)
        {
            ChartHitInfo hi = chartControl1.CalcHitInfo(e.X, e.Y);
            SeriesPoint p = hi.SeriesPoint;
            if(p!=null)
            {
                string argument = p.Argument.ToString();
                string value = p.Values[0].ToString();
                toolTipController1.ShowHint(argument +": "+ value, "SeriesPoint Data");
            }    
        }

        private void total_MouseEnter(object sender, EventArgs e)
        {
            LabelControl label = sender as LabelControl;
            label.ForeColor = Color.Blue;
        }

        private void total_MouseLeave(object sender, EventArgs e)
        {
            LabelControl label = sender as LabelControl;
            label.ForeColor = Color.FromArgb(72, 70, 68);
        }

        private void total_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sach.getList();
        }

        private void Date_Click(object sender, EventArgs e)
        {
            Home_Load(sender, e);
        }

        private void Date_MouseEnter(object sender, EventArgs e)
        {
            Date.ForeColor = Color.Blue;
        }

        private void Date_MouseLeave(object sender, EventArgs e)
        {
            Date.ForeColor = Color.Gray;
        }

        private void borrow_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sach.getListBeingBorrowed();
        }

        private void Available_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sach.getListAvailable();
        }

        private void Display_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sach.getListBeingDisplayed();
        }

        private void Others_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sach.getListLost();
        }
    }
}