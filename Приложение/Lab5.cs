using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Приложение
{
    public partial class Lab5 : Form
    {
        public Lab5()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "\t1. Промоделировать два простейших потока;" + "\n2.Получить суммарный поток складывая x(t) " +
                "соответствующих интервалов.Построить графики х1(n), x2(n), x(n), где n - № интервала, х1, x2, x - количество вызовов," +
                " попавших в интервал для I, II и суммарного потока соответственно." + "\n3.Для суммарного потока получить Лямбдасум модельное." +
                "\n4.Сравнить полученное значение Лямбдасум и Лямбда1 + Лямбда2." + "\n5.Рассчитать оценки дисперсии и математического" +
                " ожидания случайной величины x(t) - количество вызовов суммарного потока, попавших в интервал t."
               , "Задание");
        }

        static private double Rand(double a, double b, Random random)
        {
            double x = random.Next(300000);
            x /= 300000;
            return a + (b - a) * x;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int a = 0, b = 1;
            double N = double.Parse(textBox1.Text);
            double l1 = 10 * (N + 1) / (N + 4);
            double l2 = 15 * (N + 1) / (N + 4);
            int n = int.Parse(textBox2.Text);//кол-во записей
            double[] r1 = new double[n];///рандомные значения от 0 до 1
            double[] z1 = new double[n];///случайные значения с параметром l
            double[] t1 = new double[n];///последовательность  моментов поступления вызова
            double[] r2 = new double[n];///рандомные значения от 0 до 1
            double[] z2 = new double[n];///случайные значения с параметром l
            double[] t2 = new double[n];///последовательность моментов поступления вызова
            int[] x1 = new int[24];
            int[] x2 = new int[24];
            for (int i = 0; i < n; i++)
            {
                r1[i] = Rand(a, b, random);
                z1[i] = -1 / l1 * Math.Log(r1[i]);
                r2[i] = Rand(a, b, random);
                z2[i] = -1 / l2 * Math.Log(r2[i]);
                listBox1.Items.Add((i + 1) + ") r1 = " + Math.Round(r1[i], 4));
                listBox2.Items.Add((i + 1) + ") z1 = " + Math.Round(z1[i], 4));
                listBox6.Items.Add((i + 1) + ") r2 = " + Math.Round(r2[i], 4));
                listBox5.Items.Add((i + 1) + ") z2 = " + Math.Round(z2[i], 4));
            }
            double T1 = 1 + N, T2 = 4 + N;
            double raz = T2 - T1;//иначе считает как ноль
            double taum = raz / 24;//длинна промежутка
            int debug1 = 0;//кол-во t1
            for (int i = 0; ; i++)
            {
                double bufz = 0;
                for (int j = 0; j < i; j++)
                {
                    bufz += z1[j];
                }
                t1[i] = T1 + bufz;
                listBox3.Items.Add((i + 1) + ") t1 = " + Math.Round(t1[i], 4));
                debug1++;
                if (t1[i] > T2) break;

            }
            double temp1 = T1 + taum;
            int k1 = 0;//счетчик x1
            for (int i = 1; i < debug1 - 1; i++)
            {
                if (t1[i] <= temp1)
                {
                    x1[k1]++;
                }
                else
                {
                    while (t1[i] > temp1)
                    {
                        temp1 += taum;
                        k1++;
                    }
                    if (k1 >= 24) break;
                    x1[k1]++;
                }
            }



            int debug2 = 0;//кол-во t2
            for (int i = 0; ; i++)
            {
                double bufz = 0;
                for (int j = 0; j < i; j++)
                {
                    bufz += z2[j];
                }
                t2[i] = T1 + bufz;
                listBox4.Items.Add((i + 1) + ") t2 = " + Math.Round(t2[i], 4));
                debug2++;
                if (t2[i] > T2) break;

            }
            double temp2 = T1 + taum;
            int k2 = 0;//счетчик x2
            for (int i = 1; i < debug2 - 1; i++)
            {
                if (t2[i] <= temp2)
                {
                    x2[k2]++;
                }
                else
                {
                    while (t2[i] > temp2)
                    {
                        temp2 += taum;
                        k2++;
                    }
                    if (k2 >= 24) break;
                    x2[k2]++;
                }
            }

            double[] x = new double[24];
            double sumx = 0;//потребуется дальше для l модельной
            for (int i = 0; i < 24; i++)
            {
                listBox9.Items.Add((i + 1) + ") x1 = " + x1[i]);
                listBox8.Items.Add((i + 1) + ") x2 = " + x2[i]);
                x[i] = x1[i] + x2[i];
                sumx += x[i];
                listBox7.Items.Add((i + 1) + ") x1+x2 = " + x[i]);

            }


            for (int i = 0; i < 24; i++)
            {
                chart1.Series[0].Points.AddXY(i, x1[i]);
                chart1.Series[1].Points.AddXY(i, x2[i]);
                chart1.Series[2].Points.AddXY(i, x[i]);
            }

            double l3model = sumx / 24 / taum;
            double l3 = l1 + l2;

            listBox10.Items.Add("lмод = " + Math.Round(l3model, 4) + "     lсум = " + Math.Round(l3, 4));

            double m = sumx / 24;//мат ожидание

            sumx = 0;
            for (int i = 0; i < 24; i++)
            {
                x[i] -= m;
                x[i] = x[i] * x[i];
                sumx += x[i];
            }
            double d = sumx / 23;//оценка дисперсии
            listBox10.Items.Add("M = " + Math.Round(m, 4) + "     D = " + Math.Round(d, 4));
        }
    }
}
