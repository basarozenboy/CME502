using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting.Chart;

namespace MonteCarloSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static readonly Random random = new Random();
        public static double GetRandomNumber(double minimum, double maximum)
        {
            { 
                return random.NextDouble() * (maximum - minimum) + minimum;
            }
        }

        private void testRandomNumberGenerator(int numbOf)
        {
            double testNumb;
            string lines = "";
            clearChart(chart2);
            for (int i = 1; i <= numbOf; i++)
            {
                testNumb = GetRandomNumber(0, 1);
                chart2.Series["test1"].Points.AddXY(i, testNumb);
                lines = lines + testNumb.ToString() + "\r\n";
            }
            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\testNumb.txt");
            file.WriteLine(lines);
            file.Close();
        }

        private void clearChart( System.Windows.Forms.DataVisualization.Charting.Chart chartx)
        {
            foreach (var series in chartx.Series)
                series.Points.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testMonteCarloSimulation();
        }

        private void testMonteCarloSimulation()
        {
            double x, y, Area;
            int K = 0;
            int N = Int32.Parse(textBox1.Text);
            string lines = "";
            clearChart(chart1);
            for (int i = 0; i < N; i++)
            {
                x = GetRandomNumber(1, 4);
                y = GetRandomNumber(0, 2);
                if ((y <= (Math.Sqrt(x) )) && (x<= 4) && (x>=1) && (y>=0) && (y<=2))
	            {
                    K++;
                    lines = lines + x.ToString() + ' ' + y.ToString() + "\r\n";
                    chart1.Series["test1"].Points.AddXY(x, y);
	            }              
            }
            Area = ((double)K /(double)N) * 2.0 * 3.0;
            textBox2.Text = Area.ToString();
            textBox3.Text = (14.0/3.0).ToString();
            textBox4.Text = Math.Abs((Area - (14.0 / 3.0))).ToString();
            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
            file.WriteLine(lines);

            file.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                Random rdn = new Random();
                for (int i = 0; i < 50; i++)
                {
                    chart1.Series["test1"].Points.AddXY
                                    (rdn.NextDouble(), rdn.NextDouble());
                    //chart1.Series["test2"].Points.AddXY
                    //                (rdn.NextDouble(), rdn.NextDouble());
                }

                //chart1.Series["test1"].ChartType = SeriesChartType.FastLine;
                //chart1.Series["test1"].Color = Color.Red;

                //chart1.Series["test2"].ChartType =
                //                    SeriesChartType.FastLine;
                //chart1.Series["test2"].Color = Color.Blue;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            testRandomNumberGenerator(1000);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            testMultyResult();
        }

        private void testMultyResult()
        {
            string lines = "";
            double x, y, Area, realResult;
            int N = Int32.Parse(textBox5.Text);
            int T = Int32.Parse(textBox7.Text);
            int Inc = Int32.Parse(textBox6.Text);
            realResult = (14.0 / 3.0);
            clearChart(chart3);
            chart3.ChartAreas[0].AxisY.Maximum = 6;
            chart3.ChartAreas[0].AxisY.Minimum = 2;
            for (int j = 0; j < T; j++)
            {
                N = N + j * Inc;
                int K = 0;
                for (int i = 0; i < N; i++)
                {
                    x = GetRandomNumber(1, 4);
                    y = GetRandomNumber(0, 2);
                    if ((y <= (Math.Sqrt(x))) && (x <= 4) && (x >= 1) && (y >= 0) && (y <= 2))
                    {
                        K++;
                    }    
                }
                Area = ((double)K / (double)N) * 2 * 3;
                chart3.Series["test1"].Points.AddXY(j, Area);
                chart3.Series["test2"].Points.AddXY(j, realResult);
                lines = lines + realResult.ToString() +' ' + Area.ToString() + ' ' + Math.Abs((Area - realResult)).ToString() + "\r\n";
            }
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
            file.WriteLine(lines);

            file.Close();
        }

        private void testMultyResult2()
        {
            string lines = "";
            double x, y, Area, realResult;
            int N = Int32.Parse(textBox5.Text);
            int T = Int32.Parse(textBox7.Text);
            int Inc = Int32.Parse(textBox6.Text);
            int j;
            realResult = (14.0 / 3.0);
            clearChart(chart3);
            chart3.ChartAreas[0].AxisY.Maximum = 6;
            chart3.ChartAreas[0].AxisY.Minimum = 2;
            //for (int j = 0; j < T; j++)
            {
                //N = N + j * Inc;
                int K = 0;
                j = 0;
                for (int i = 1; i < N; i++)
                {
                    x = GetRandomNumber(1, 4);
                    y = GetRandomNumber(0, 2);
                    if ((y <= (Math.Sqrt(x))) && (x <= 4) && (x >= 1) && (y >= 0) && (y <= 2))
                    {
                        K++;
                    }

                    if ( (i % 100) == 0 )
                    {
                        j = j + 1;
                        Area = ((double)K / (double)i) * 2 * 3;
                        chart3.Series["test1"].Points.AddXY(j, Area);
                        chart3.Series["test2"].Points.AddXY(j, realResult);
                    }
                }

               // lines = lines + realResult.ToString() + ' ' + Area.ToString() + ' ' + Math.Abs((Area - realResult)).ToString() + "\r\n";
            }
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
            file.WriteLine(lines);

            file.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            testMultyResult2();
        }
    }
}
