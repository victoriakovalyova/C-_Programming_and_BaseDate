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
    public partial class Lab4 : Form
    {
        public Lab4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "\tНаписать программу рекуррентной " +
                "оценки математического ожидания случайной величины Y. Эта случайная величина является результатом следующего " +
                "преобразования Гауссовской случайной величины Х " +
                "(с математическим ожиданием 0 и дисперсией 1):" +
                "\ny = x^2, при x > 0\n y = 0, при других x \n" +
                "\tВывести на график рекуррентную оценку математического ожидания в зависимости от количества отсчетов, участвующих в оценке." +
                " На этот же график вывести прямую истинного математического ожидания. \r\n", "Задание 1");
        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            // Очистка данных на втором графике
            chart1.Series.Clear();

            double exp1 = Convert.ToDouble(textBox1.Text);
            Random random = new Random();

            double[] e_ = new double[(int)exp1];
            double[] m_rek = new double[(int)exp1];
            double[] m_ist = new double[(int)exp1];

            Normal normal = new Normal(0, Math.Sqrt(1));

            if ((exp1 != 0))
            {
                int[] num = new int[(int)exp1];

                for (int i = 0; i < exp1; i++)
                {
                    num[i] = i + 1;
                }

                double m_ist_ = 0.0;
                for (int k = 0; k < (int)exp1; k++)
                {

                    for (int i = 0; i < (int)exp1; i++)
                    {
                        m_ist[i] = Math.Exp(-0.5 * 0.5 / 2.0) / Math.Sqrt(2 * 3.14);
                    }
                    for (int i = 0; i < (int)exp1; i++)
                    {
                        e_[i] = normal.Sample();
                        if (e_[i] <= 0)
                        {
                            e_[i] = 0;
                        }
                    }
                    m_rek[1] = e_[1];
                    for (int i = 2; i < (int)exp1; i++)
                    {
                        m_rek[i] = (i - 1.0) / i * m_rek[i - 1] + 1.0 / i * e_[i];
                    }

                    m_ist_ = m_ist[k];
                }

                // Добавление серий данных на второй график
                Series series1 = chart1.Series.Add("Рекур.оценка M(x)");
                Series series2 = chart1.Series.Add("Истинная M(x)");

                series1.ChartType = SeriesChartType.Spline;
                series2.ChartType = SeriesChartType.Spline;

                series1.Points.DataBindXY(num, m_rek);
                series2.Points.DataBindXY(num, m_ist);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "\tНаписать программу рекуррентной оценки дисперсии случайной величины Y, " +
                "которая является результатом следующего преобразования Гауссовской случайной величины Х" +
                " (с математическим ожиданием 0 и дисперсией 1): " +
                "\ny = x^2, при x > 0\n y = 0, при других x \n" +
                "\tВывести на график рекуррентную оценку дисперсии в зависимости от количества отсчетов, " +
                "участвующих в оценке, и прямую истинного значения дисперсии.", "Задание 2");
        }
    

        private void button3_Click(object sender, EventArgs e)
        {
            // Очистка данных на втором графике
            chart2.Series.Clear();

            double exp1 = Convert.ToDouble(textBox3.Text);

            Random random = new Random();


            if ((exp1 != 0))
            {
                int[] num = new int[(int)exp1];

                for (int i = 0; i < exp1; i++)
                {
                    num[i] = i + 1;
                }

                double[] e_ = new double[(int)exp1];
                double[] m_rek = new double[(int)exp1];
                double[] m_ist = new double[(int)exp1];

                double[] x = new double[(int)exp1];
                double[] d_rek = new double[(int)exp1];
                double[] d_ist = new double[(int)exp1];

                Normal normal = new Normal(0, Math.Sqrt(1));


                double d_ist_ = 0.0;
                for (int k = 0; k < exp1; k++)
                {

                    for (int i = 0; i < exp1; i++)
                    {
                        d_ist[i] = (3.14 - 2.0) / 3.14;
                    }
                    for (int i = 0; i < exp1; i++)
                    {
                        x[i] = normal.Sample();
                        if (x[i] <= 0)
                        {
                            x[i] = 0;
                        }
                    }
                    d_rek[1] = 0;
                    m_rek[1] = x[0];
                    for (int i = 2; i < exp1; i++)
                    {
                        m_rek[i] = (i - 1.0) / i * m_rek[i - 1] + 1.0 / i * x[i];
                    }
                    for (int i = 2; i < exp1; i++)
                    {
                        d_rek[i] = (i - 1f) / i * d_rek[i - 1] + 1f / i * (x[i] - m_rek[i]) * (x[i] - m_rek[i]);
                    }
                    d_ist_ = d_ist[k];
                }

                // Добавление серий данных на второй график
                Series series1 = chart2.Series.Add("Рекур.оценка D(x)");
                Series series2 = chart2.Series.Add("Истинная D(x)");

                series1.ChartType = SeriesChartType.Spline;
                series2.ChartType = SeriesChartType.Spline;

                series1.Points.DataBindXY(num, d_rek);
                series2.Points.DataBindXY(num, d_ist);
            }
        }
    }
}
