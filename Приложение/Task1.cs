using MathNet.Numerics.Distributions;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();

            // Добавляем обработчики событий для кнопок пересчета

            // Обработчик для кнопки button1
            button1.Click += (sender, e) =>
            {
                chart1.Series.Clear();
                double exp1 = Convert.ToDouble(textBox1.Text);
                double exp2 = Convert.ToDouble(textBox2.Text);

                Random random = new Random();

                if ((exp1 != 0) && (exp2 != 0))
                {
                    // Генерация данных для первого набора
                    double[] data1 = new double[(int)exp1];
                    for (int i = 0; i < exp1; i++)
                    {
                        double value = random.NextDouble() * 9 - 2;
                        data1[i] = value;
                    }

                    // Генерация данных для второго набора
                    double[] data2 = new double[(int)exp2];
                    for (int i = 0; i < exp2; i++)
                    {
                        double value = random.NextDouble() * 9 - 2;
                        data2[i] = value;
                    }

                    // Добавление серий данных на график
                    Series series1 = chart1.Series.Add("Series1");
                    Series series2 = chart1.Series.Add("Series2");

                    series1.ChartType = SeriesChartType.Spline;
                    series2.ChartType = SeriesChartType.Spline;

                    series1.Points.DataBindXY(pointX(-2, 7), pointY(data1, 10, exp1));
                    series2.Points.DataBindXY(pointX(-2, 7), pointY(data2, 10, exp2));
                }
            };

            // Обработчик для кнопки button2
            button2.Click += (sender, e) =>
            {
                double N = Convert.ToDouble(textBox3.Text);

                Series series = chart2.Series["Series1"];
                series.ChartType = SeriesChartType.Column;

                series.Points.Clear();

                int[] values = { 5, 7, 17, 19, 21, 25, 55 };
                double[] chance = { 0.01, 0.05, 0.3, 0.3, 0.3, 0.02, 0.02 };
                int[] allval = new int[(int)N];
                double[] ammval = new double[values.Length];

                Random random = new Random();

                if (N != 0)
                {
                    // Генерация данных и заполнение гистограммы
                    for (int j = 0; j < N; j++)
                    {
                        double randomval = random.NextDouble();
                        double cprob = 0.0;
                        int result = 0;
                        for (int i = 0; i < chance.Length; i++)
                        {
                            cprob += chance[i];
                            if (randomval < cprob)
                            {
                                result = values[i];
                                ammval[i] += 1 / N;
                                break;
                            }
                        }
                        allval[j] = result;
                    }

                    for (int i = 0; i < values.Length; i++)
                    {
                        series.Points.AddXY(values[i].ToString(), ammval[i]);
                    }
                }
            };

            // Обработчик для кнопки button3
            button3.Click += (sender, e) =>
            {
                double N = Convert.ToDouble(textBox4.Text);
                Random random = new Random();

                Series series = chart3.Series["Series1"];
                series.ChartType = SeriesChartType.Spline;

                double[] arrayZ = new double[(int)N];
                double[] arrayX = new double[(int)N];
                double[] arrayY = new double[(int)N];

                if (N != 0)
                {
                    // Генерация данных и построение графика
                    for (int i = 0; i < N; i++)
                    {
                        double value = random.NextDouble() * (7 - 5) + 5;
                        arrayZ[i] = value;

                        Normal normal = new Normal(3, Math.Sqrt(2));
                        arrayX[i] = normal.Sample();

                        arrayY[i] = arrayX[i] + arrayZ[i];
                    }

                    int minY = (int)Math.Floor(arrayY.Min());
                    int maxY = (int)Math.Floor(arrayY.Max());

                    series.Points.DataBindXY(pointX(minY, maxY), pointY(arrayY, maxY - minY + 1, N));
                }
            };
        }

        // Метод для генерации массива X точек по оси X
        double[] pointX(int min, int max)
        {
            int len = max - min;
            double[] xpoints = new double[len + 1];

            for (int i = 0; i < len + 1; i++)
            {
                xpoints[i] = i + min;
            }

            return xpoints;
        }

        // Метод для генерации массива Y точек по оси Y
        double[] pointY(double[] data, int bins, double n)
        {
            double[] ypoints = new double[bins];
            double min = data.Min();
            double max = data.Max();
            double binWidth = (max - min) / bins;
            double binn = 1 / n;

            foreach (var value in data)
            {
                int index = (int)Math.Floor((value - min) / binWidth);
                if (index >= 0 && index < bins)
                    ypoints[index] += binn;
            }
            return ypoints;
        }

    }
}
