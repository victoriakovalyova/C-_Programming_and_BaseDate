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
using MathNet.Numerics.Distributions;

namespace Приложение
{
    public partial class Lab1 : Form
    {
        public Lab1()
        {
            InitializeComponent();
        }
        // Добавляем обработчики событий для кнопок пересчета

        // Обработчик для кнопки button1
        private void button2_Click(object sender, EventArgs e)
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
                Series series1 = chart1.Series.Add("Число экспирементов 1");
                Series series2 = chart1.Series.Add("Число экспирементов 2");

                series1.ChartType = SeriesChartType.Spline;
                series2.ChartType = SeriesChartType.Spline;

                series1.Points.DataBindXY(pointX(-2, 7), pointY(data1, 10, exp1));
                series2.Points.DataBindXY(pointX(-2, 7), pointY(data2, 10, exp2));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "   Написать программный датчик случайной величины с равномерной" +
                " плотностью распределения вероятности в интервале от -2 до 7. " +
                "Затем написать вызывающую функцию, которая выводит на график две экспериментальные " +
                "зависимости плотности распределения вероятности. Отличием этих двух зависимостей является " +
                "различное число экспериментов (для построения одной зависимости используется значительно большее " +
                "число экспериментов).",
                "Задание 1");
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
        // Обработчик для кнопки button2
        private void button3_Click(object sender, EventArgs e)
        {
            double N = Convert.ToDouble(textBox3.Text);

            Series series = chart2.Series["Число экспирементов"];
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "	Необходимо смоделировать реализацию случайной величины Х," +
                " которая может принимать 7 значений 5, 7, 17, 19, 21, 25, 55 со следующими вероятностями: " +
                "Р(Х=5) = 0.01, Р(Х=7) = 0.05, Р(Х=17) = 0.3, Р(Х=19) = 0.3, P(X=21) = 0.3, P(X=25) = 0.02, P(X=55) = 0.02.",
                "Задание 2");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double N = Convert.ToDouble(textBox4.Text);
            Random random = new Random();

            Series series = chart3.Series["Функция плотности"];
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
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "	Построить экспериментальную кривую плотности распределения вероятности случайной величины Y, " +
                "которая задается суммой двух случайных величин: Y = X + Z, при этом Х имеет гауссовскую " +
                "плотность распределения вероятности с математическим ожиданием 3 и дисперсией" +
                " 2, а Z имеет равномерную плотность распределения вероятности в интервале от 5 до 7.", "Задание 3");
        }
    }
}
