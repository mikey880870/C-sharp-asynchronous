using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace week6
{
    internal class Method
    {
        public static List<string> Open_Show()
        {
            List<string> filenames=new List<string>();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter= "All Files|*.*";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filenames = ofd.FileNames.ToList();
                MessageBox.Show("選取成功");
            }
            return filenames;
        }

        public async static Task<List<double>> bitmap_to_graydata(Bitmap input)
        {
            List<double> Data=new List<double>();
            await Task.Run(() =>
            {
                for (int i = 0; i < input.Width; i++)
                {
                    int gray_sum = 0;
                    for (int j = 0; j < input.Height; j++)
                    {
                        Color P = input.GetPixel(i, j);
                        int Gray = (P.R * 313524 + P.G * 615514 + P.B * 119538) >> 20;
                        gray_sum += Gray;
                    }
                    Data.Add(gray_sum / input.Height);
                }
            }
            );
            return Data;
        }

        delegate void charUpdate(System.Windows.Forms.DataVisualization.Charting.Series series);
       
    }
}
