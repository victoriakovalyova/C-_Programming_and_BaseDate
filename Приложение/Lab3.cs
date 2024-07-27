using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization.Charting;

namespace Приложение
{
    public partial class Lab3 : Form
    {
        public Lab3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Написать программу прохождения белого шума через линейную систему с импульсной" +
                " характеристикой k(t) = 0.2 cos(0.5t+7) при 0 ≤ t ≤ 5.", "Задание");
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Очищаем график перед построением новых данных
            chart1.Series.Clear();

            // Получаем значение числа экспериментов от пользователя
            double numberOfSamples = Convert.ToDouble(textBox3.Text);
            Random random = new Random();

            if (numberOfSamples != 0)
            {
                // Генерируем индексы для точек на графике
                int[] indices = new int[(int)numberOfSamples];
                for (int i = 0; i < numberOfSamples; i++)
                {
                    indices[i] = i + 1;
                }

                // Параметры линейной системы
                int L = 5;
                double[] inputSignal = new double[(int)numberOfSamples];
                double[] outputSignal = new double[(int)numberOfSamples];
                double[] impulseResponse = new double[L + 1];

                // Генерация белого шума
                for (int i = 0; i < (int)numberOfSamples; i++)
                {
                    inputSignal[i] = NextGaussian(random);
                }

                // Вычисление импульсной характеристики системы
                for (int i = 0; i <= L; i++)
                {
                    impulseResponse[i] = 0.2 * Math.Cos(0.5 * i + 7);
                }

                // Прохождение сигнала через систему
                for (int i = 0; i < (int)numberOfSamples; i++)
                {
                    outputSignal[i] = 0;

                    for (int p = 0; p < L; p++)
                    {
                        if ((i - p) >= 0) outputSignal[i] += inputSignal[i - p] * impulseResponse[p];
                    }
                }

                // Добавление серий данных на график
                Series inputSeries = chart1.Series.Add("Входной сигнал");
                Series outputSeries = chart1.Series.Add("Выходной сигнал");

                inputSeries.ChartType = SeriesChartType.Spline;
                outputSeries.ChartType = SeriesChartType.Spline;

                // Привязываем данные к точкам на графике
                inputSeries.Points.DataBindXY(indices, inputSignal);
                outputSeries.Points.DataBindXY(indices, outputSignal);
            }
        }
        // Генерация случайной величины с нормальным распределением
        public static double NextGaussian(Random random, double mean = 0, double standardDeviation = 1)
        {
            var u1 = random.NextDouble();
            var u2 = random.NextDouble();

            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            var randNormal = mean + standardDeviation * randStdNormal;

            return randNormal;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
