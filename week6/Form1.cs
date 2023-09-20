using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace week6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisY.Maximum = 250;
            chart2.ChartAreas[0].AxisY.Maximum = 250;
            chart3.ChartAreas[0].AxisY.Maximum = 250;
            chart4.ChartAreas[0].AxisY.Maximum = 250;
            chart5.ChartAreas[0].AxisY.Maximum = 250;
        }
        
        private void FileBTN_Click(object sender, EventArgs e)
        {
            List<string> files = new List<string>();
            files=Method.Open_Show();
            pictureBox1.Image = Image.FromFile(files[0]);
            pictureBox2.Image = Image.FromFile(files[1]);
            pictureBox3.Image = Image.FromFile(files[2]);
            pictureBox4.Image = Image.FromFile(files[3]);
            pictureBox5.Image = Image.FromFile(files[4]);
            FileBTN.Enabled = false;
        }

        private async void PlotBTN_Click(object sender, EventArgs e)
        {
            Task<List<double>> p1_data = Method.bitmap_to_graydata((Bitmap)pictureBox1.Image);
            Task<List<double>> p2_data = Method.bitmap_to_graydata((Bitmap)pictureBox2.Image);
            Task<List<double>> p3_data = Method.bitmap_to_graydata((Bitmap)pictureBox3.Image);
            Task<List<double>> p4_data = Method.bitmap_to_graydata((Bitmap)pictureBox4.Image);
            Task<List<double>> p5_data = Method.bitmap_to_graydata((Bitmap)pictureBox5.Image);

            List<double> Data1 = await p1_data;
            for (int i = 0; i < Data1.Count; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, Data1[i]);
            }
            List<double> Data2 = await p2_data;
            for (int i = 0; i < Data2.Count; i++)
            {
                chart2.Series["Series1"].Points.AddXY(i, Data2[i]);
            }
            List<double> Data3 = await p3_data;
            for (int i = 0; i < Data3.Count; i++)
            {
                chart3.Series["Series1"].Points.AddXY(i, Data3[i]);
            }
            List<double> Data4 = await p4_data;
            for (int i = 0; i < Data4.Count; i++)
            {
                chart4.Series["Series1"].Points.AddXY(i, Data4[i]);
            }
            List<double> Data5 = await p5_data;
            for (int i = 0; i < Data5.Count; i++)
            {
                chart5.Series["Series1"].Points.AddXY(i, Data5[i]);
            }

        }

      
    }
}
