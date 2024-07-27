using MathNet.Numerics.Distributions;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Приложение
{
    public partial class Lab2 : Form
    {
        public Lab2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Очистка данных на первом графике
            chart1.Series.Clear();

            // Получение значения экспоненты от пользователя
            double numberOfSamples = Convert.ToDouble(textBox1.Text);

            if (numberOfSamples != 0)
            {
                // Параметры для расчета гауссовского процесса с экспоненциальной функцией корреляции
                double mean = 2;
                double variance = 5;
                double correlationCoefficient = 0.95;

                // Создание объекта нормального распределения
                Normal normalDistribution = new Normal(mean, Math.Sqrt(variance));

                // Массив для хранения значений гауссовского процесса
                double[] processValues = new double[(int)numberOfSamples];

                // Переменные для расчета значений гауссовского процесса
                double previousValue, currentRandomSample, k1, k2;
                k2 = Math.Exp(-correlationCoefficient);
                k1 = Math.Sqrt(variance * (1.0 - k2 * k2));

                // Получение первого случайного значения
                processValues[0] = normalDistribution.Sample();

                // Генерация значений гауссовского процесса
                for (int n = 1; n < numberOfSamples; n++)
                {
                    currentRandomSample = normalDistribution.Sample();
                    processValues[n] = k1 * currentRandomSample + k2 * processValues[n - 1];
                }

                // Количество точек для расчета корреляционной функции
                int P = (int)(2.0 / correlationCoefficient);
                int numberOfRealizations = (int)numberOfSamples - 2 * P;

                // Массив для корреляционной функции
                double[] correlationFunction = new double[(int)numberOfSamples];

                for (int m = 0; m < (int)numberOfSamples; m++)
                {
                    correlationFunction[m] = 0;
                    for (int n = 0; n < (numberOfRealizations - m - 1); n++)
                        correlationFunction[m] += 1 / (double)(numberOfRealizations - m) * processValues[n] * processValues[n + m];
                }

                // Добавление серий данных на первый график
                Series series1 = chart1.Series.Add("Процесс");
                Series series2 = chart1.Series.Add("Кор. функция");

                series1.ChartType = SeriesChartType.Spline;
                series2.ChartType = SeriesChartType.Spline;

                // Создание массива для номеров точек
                int[] pointNumbers = Enumerable.Range(1, (int)numberOfSamples).ToArray();

                // Привязка данных к точкам на графике
                series1.Points.DataBindXY(pointNumbers, processValues);
                series2.Points.DataBindXY(pointNumbers, correlationFunction);
            }
        }
        /*
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Разработать программу моделирования Гауссовского случайного процесса с функцией корреляции R(m) = Dexp(-a2m2 ). Параметр D " +
                "процесса выбрать равным 5, а параметр а = 0.01. Программа должна вывести на экран реализацию процесса. Также программа должна " +
                "вывести на экран оценку (поэкспериментальным данным) корреляционной функции по реализации процесса. ", "Задание 2");
        }*/


      /*  private void button3_Click(object sender, EventArgs e)
        {
            // Очистка данных на втором графике
            chart2.Series.Clear();

            // Получение значения N от пользователя
            double N = Convert.ToDouble(textBox3.Text);

            if (N != 0)
            {
                // Параметры для расчета гауссовского процесса с функцией корреляции R(m) = D * exp(-a^2 * m^2)
                double D = 5;
                double M = 0;
                double a = 0.01;

                // Создание объекта нормального распределения
                Normal normalDistribution = new Normal(M, Math.Sqrt(D));

                // Проверка минимального значения N
                if (N < 201)
                {
                    N = 201;
                }

                // Массивы для хранения значений гауссовского процесса и вспомогательных коэффициентов
                double[] processValues = new double[(int)N];
                double[] randomSamples = new double[(int)N];
                double[] c = new double[(int)N];

                // Генерация случайных значений
                for (int n = 0; n < N; n++)
                    randomSamples[n] = normalDistribution.Sample();

                // Расчет коэффициентов c
                int P = (int)(2.0 / a);
                for (int k = 0; k < P; k++)
                {
                    c[k] = Math.Sqrt(2 * D * a) / Math.Pow(Math.PI, 1.0 / 4) * Math.Exp(-2 * a * a * k * k);
                }

                // Генерация значений гауссовского процесса
                for (int n = 0; n < N; n++)
                {
                    for (int k = -P; k <= P; k++)
                    {
                        double aa = (k < 0) ? c[-k] : c[k];

                        if (((n - k) >= 0) && ((n - k) < N))
                            processValues[n] += aa * randomSamples[n - k];
                    }
                }

                // Избавление от ненужных значений в начале
                for (int n = 0; n < (N - 2 * P); n++)
                    processValues[n] = processValues[n + P];

                int numberOfRealizations = (int)N - 2 * P;

                // Массив для корреляционной функции
                double[] correlationFunction = new double[(int)N];

                for (int m = 0; m < N; m++)
                {
                    correlationFunction[m] = 0;
                    for (int n = 0; n < (numberOfRealizations - m - 1); n++)
                        correlationFunction[m] += 1 / (float)(numberOfRealizations - m) * processValues[n] * processValues[n + m];
                }

                // Добавление серий данных на второй график
                Series series1 = chart2.Series.Add("Процесс");
                Series series2 = chart2.Series.Add("Кор.функция");

                series1.ChartType = SeriesChartType.Spline;
                series2.ChartType = SeriesChartType.Spline;

                // Создание массива для номеров точек
                int[] pointNumbers = Enumerable.Range(1, (int)N).ToArray();

                // Привязка данных к точкам на графике
                series1.Points.DataBindXY(pointNumbers, processValues);
                series2.Points.DataBindXY(pointNumbers, correlationFunction);
            }
        
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Разработать программу моделирования Гауссовского случайного процесса с экспоненциальной функцией корреляции." +
                " Параметры процесса выбрать следующими: математическое ожидание равно 2, " +
                "дисперсия равна 5, а коэффициент корреляции соседних отсчетов процесса равен р(1) = 0.95. " +
                "Программа должна вывести на экран реализацию процесса. Также программа должна" +
                " вывести на экран оценку (по экспериментальным данным) корреляционной функции по реализации процесса. ", "Задание 1");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // Очистка данных на втором графике
            chart2.Series.Clear();

            // Получение значения N от пользователя
            double N = Convert.ToDouble(textBox3.Text);

            if (N != 0)
            {
                // Параметры для расчета гауссовского процесса с функцией корреляции R(m) = D * exp(-a^2 * m^2)
                double D = 5;
                double M = 0;
                double a = 0.01;

                // Создание объекта нормального распределения
                Normal normalDistribution = new Normal(M, Math.Sqrt(D));

                // Проверка минимального значения N
                if (N < 201)
                {
                    N = 201;
                }

                // Массивы для хранения значений гауссовского процесса и вспомогательных коэффициентов
                double[] processValues = new double[(int)N];
                double[] randomSamples = new double[(int)N];
                double[] c = new double[(int)N];

                // Генерация случайных значений
                for (int n = 0; n < N; n++)
                    randomSamples[n] = normalDistribution.Sample();

                // Расчет коэффициентов c
                int P = (int)(2.0 / a);
                for (int k = 0; k < P; k++)
                {
                    c[k] = Math.Sqrt(2 * D * a) / Math.Pow(Math.PI, 1.0 / 4) * Math.Exp(-2 * a * a * k * k);
                }

                // Генерация значений гауссовского процесса
                for (int n = 0; n < N; n++)
                {
                    for (int k = -P; k <= P; k++)
                    {
                        double aa = (k < 0) ? c[-k] : c[k];

                        if (((n - k) >= 0) && ((n - k) < N))
                            processValues[n] += aa * randomSamples[n - k];
                    }
                }

                // Избавление от ненужных значений в начале
                for (int n = 0; n < (N - 2 * P); n++)
                    processValues[n] = processValues[n + P];

                int numberOfRealizations = (int)N - 2 * P;

                // Массив для корреляционной функции
                double[] correlationFunction = new double[(int)N];

                for (int m = 0; m < N; m++)
                {
                    correlationFunction[m] = 0;
                    for (int n = 0; n < (numberOfRealizations - m - 1); n++)
                        correlationFunction[m] += 1 / (float)(numberOfRealizations - m) * processValues[n] * processValues[n + m];
                }

                // Добавление серий данных на второй график
                Series series1 = chart2.Series.Add("Процесс");
                Series series2 = chart2.Series.Add("Кор.функция");

                series1.ChartType = SeriesChartType.Spline;
                series2.ChartType = SeriesChartType.Spline;

                // Создание массива для номеров точек
                int[] pointNumbers = Enumerable.Range(1, (int)N).ToArray();

                // Привязка данных к точкам на графике
                series1.Points.DataBindXY(pointNumbers, processValues);
                series2.Points.DataBindXY(pointNumbers, correlationFunction);
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Разработать программу моделирования Гауссовского случайного процесса с функцией корреляции R(m) = Dexp(-a2m2 ). Параметр D " +
                "процесса выбрать равным 5, а параметр а = 0.01. Программа должна вывести на экран реализацию процесса. Также программа должна " +
                "вывести на экран оценку (поэкспериментальным данным) корреляционной функции по реализации процесса. ", "Задание 2");
        }
    }
}
