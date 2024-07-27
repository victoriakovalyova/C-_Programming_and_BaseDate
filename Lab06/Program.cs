using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TIPISLab6
{
    internal static class Program
    {
        static void Main()
        {
            Form form = new Form();

            Chart chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());
            chart.Width = 600;
            chart.Dock = DockStyle.Left;
            form.Controls.Add(chart);

            Series series1 = new Series();
            series1.BorderWidth = 4;
            series1.ChartType = SeriesChartType.Spline;
            series1.Name = "Pi";
            chart.Series.Add(series1);

            Series series2 = new Series();
            series2.BorderWidth = 4;
            series2.ChartType = SeriesChartType.Spline;
            series2.Name = "Pi-1    ";
            chart.Series.Add(series2);

            Legend legend = new Legend();
            chart.Legends.Add(legend);

            Label label = new Label();
            label.Text = "V";
            label.Location = new System.Drawing.Point(685, 10);
            form.Controls.Add(label);

            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Maximum = 100000;
            numericUpDown.Location = new System.Drawing.Point(635, 35);
            form.Controls.Add(numericUpDown);

            Label label1 = new Label();
            label1.Text = "N";
            label1.Location = new System.Drawing.Point(685, 62);
            form.Controls.Add(label1);

            Label label2 = new Label();
            label2.Text = "Пересечение: ...";
            label2.Location = new System.Drawing.Point(620, 420);
            label2.Width = 500;
            form.Controls.Add(label2);

            Label ErlText = new Label();
            ErlText.Text = "Потерянная нагрузка /\\: ...";
            ErlText.Location = new System.Drawing.Point(620, 220);
            ErlText.Width = 500;
            form.Controls.Add(ErlText);

            Label Pb = new Label();
            Pb.Text = "Вероятность потери вызова Pb(/\\): ...";
            Pb.Location = new System.Drawing.Point(620, 245);
            Pb.Width = 500;
            form.Controls.Add(Pb);

            Label Pt = new Label();
            Pt.Text = "Вероятность потерь по времени Pt(/\\): ...";
            Pt.Location = new System.Drawing.Point(620, 270);
            Pt.Width = 500;
            form.Controls.Add(Pt);

            Label Pn = new Label();
            Pn.Text = "Вероятность потерь на нагрузке Pn(/\\): ...";
            Pn.Location = new System.Drawing.Point(620, 295);
            Pn.Width = 500;
            form.Controls.Add(Pn);

            Label Ytext = new Label();
            Ytext.Text = "Обслуженная нагрузка Y: ...";
            Ytext.Location = new System.Drawing.Point(620, 320);
            Ytext.Width = 500;
            form.Controls.Add(Ytext);

            Label Rtext = new Label();
            Rtext.Text = "Избыточная нагрузка R: ...";
            Rtext.Location = new System.Drawing.Point(620, 345);
            Rtext.Width = 500;
            form.Controls.Add(Rtext);


            Label Atext = new Label();
            Atext.Text = "Потенциальная нагрузка A: ...";
            Atext.Location = new System.Drawing.Point(620, 370);
            Atext.Width = 500;
            form.Controls.Add(Atext);

            NumericUpDown numericUpDown1 = new NumericUpDown();
            numericUpDown1.Maximum = 100000;
            numericUpDown1.Location = new System.Drawing.Point(635, 85);
            form.Controls.Add(numericUpDown1);

            form.Size = new System.Drawing.Size(1000, 500);

            Button button = new Button();
            button.Text = "Пересчёт";
            button.Location = new System.Drawing.Point(655, 120);
            form.Controls.Add(button);
            button.Click += (sender, e) =>
            {
                double V = Convert.ToDouble(numericUpDown.Value);
                double N = Convert.ToDouble(numericUpDown1.Value);


                ///////////////////////////////////////////////
                Random random = new Random();


                if ((V != 0) && (N != 0))
                {

                    chart.ChartAreas[0].AxisY.Title = "Pi";
                    chart.ChartAreas[0].AxisX.Title = "/\\";
                    chart.ChartAreas[0].AxisY.Maximum = 1;
                    chart.ChartAreas[0].AxisY.Interval = 0.1;

                    double[] pi = new double[16];
                    double[] pi2 = new double[16];

                    for (int i = 0; i < 16; i++)
                    {
                        pi[i] = Pi(V, i, V);
                        pi2[i] = Pi(V - 1, i, V);
                        if (pi[i] == pi2[i]) label2.Text = "Пересечение: X: " + i.ToString() + "; Y: " + pi[i].ToString();
                    }


                    double Erl = 10 * (N + 1) / (N + 4);
                    double PoVizovu = Pi(V, Erl, V);
                    double PoVremeni = Pi(V, Erl, V);
                    double PoNagruzke = Pi(V, Erl, V);
                    double Y = Erl * (1 - Pi(V, Erl, V));
                    double R = Erl * Pi(V, Erl, V);
                    double A = Erl;

                    ErlText.Text = "Потерянная нагрузка /\\: " + Erl.ToString();
                    Pb.Text = "Вероятность потери вызова Pb(/\\): " + PoVizovu.ToString();
                    Pt.Text = "Вероятность потерь по времени Pt(/\\): " + PoVremeni.ToString();
                    Pn.Text = "Вероятность потерь на нагрузке Pn(/\\): " + PoNagruzke.ToString();
                    Ytext.Text = "Обслуженная нагрузка Y: " + Y.ToString();
                    Rtext.Text = "Избыточная нагрузка R: " + R.ToString();
                    Atext.Text = "Потенциальная нагрузка A: " + A.ToString();


                    int[] num = new int[pi.Length];

                    for (int i = 0; i < pi.Length; i++)
                    {
                        num[i] = i + 1;
                    }



                    series1.Points.DataBindXY(num, pi);
                    series2.Points.DataBindXY(num, pi2);

                };
                ///////////////////////////////////////////////
            };

            form.ShowDialog();
        }


        public static double Pi(double i, double Erl, double v)
        {
            double sumErl = 0;
            double pi = 0;

            for (int j = 0; j <= v; j++)
            {
                sumErl += Math.Pow(Erl, j) / Fact(j);
            }
            pi = (Math.Pow(Erl, i) / Fact((int)i)) / sumErl;

            return pi;
        }

        public static long Fact(long n)
        {
            if (n == 0)
                return 1;
            else
                return n * Fact(n - 1);
        }
    }
}