using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();

        const int V_busy = 2;

        double t1 = 1, t2 = 200, h = -1;
        int V = 0, N = 200, countPost = 0, countPoter = 0;

        List<double> tp = new List<double>();
        List<double> to = new List<double>();
        List<double> links = new List<double>();
        List<double> p = new List<double>();
        public double lm()
        {
            double x = 10d * (N + 1d) / (N + 4d);
            return x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
            tp.Clear();
            to.Clear();
            links.Clear();
            p.Clear();

            countPost = 0;
            countPoter = 0;
            t1 = 1;
            t2 = 200;
            N = int.Parse(textBox2.Text);
            V = int.Parse(textBoxN.Text);
            h = double.Parse(textBoxAvgTimeObsluz.Text);
            t1 += N;
            t2 += N;

            for (int i = 0; i < N; i++)
            {
                tp.Add(Math.Round((rnd.NextDouble() * (t2 - t1) + t1), 2));
            }

            tp.Sort();

            for (int i = 0; i < V; i++)
            {
                links.Add(-1);
            }

            for (int i = 0; i < V_busy; i++)
            {
                links[i] = tp[i] + (k()/100);
            }

            for (int i = 0; i < tp.Count; i++)
            {
                if (tp[i] <= t2)
                {

                    int d = countPost;
                    for (int j = 0; j < links.Count; j++)
                    {
                        if (tp[i] > links[j])
                        {
                            to.Add(tp[i] + k()/100);
                            links[j] = to[to.Count - 1];
                            //textBox9.Text += (i + 1) + " - " + tp[i] + " - " + k() + " - " + Math.Round(to[to.Count - 1], 2) + " -- " + (j + 1) + "| \r\n";
                            dataGridView1.Rows.Add((i + 1), rnd.NextDouble(), findZ(10d * (N + 1d) / (N + 4d), tp[i]), k(), tp[i], Math.Round(to[to.Count - 1], 2), (j + 1));
                            countPost++;
                            break;
                        }
                    }
                    if (d == countPost)
                    {
                        countPoter++;
                        //textBox9.Text += (i + 1) + ".\r\n";
                        dataGridView1.Rows.Add((i + 1), "-", "-", "-", "-", "-", "-");
                    }
                }
            }

            label9.Text = "Потери: " + countPoter.ToString();
            label10.Text = "Вызовы: " + N.ToString();


            label1.Text = "Потери по эксперименту: " + Math.Round(countPoter / double.Parse(N.ToString()), 4).ToString();


            label8.Text = "Потери по Эрлангу: " + Math.Round(formulaErlang(V, lm() * h / 60), 4).ToString();
        }

        public double k()
        {
            return -h * Math.Log(rnd.NextDouble());
        }



        public double factorial(double n)
        {
            if (n == 0) return 1;
            return n * factorial(n - 1);
        }

        public double findZ(double lambda, double r)
        {
            return (1 / lambda) * Math.Log(r);
        }



        public double formulaErlang(double i, double Erl)
        {
            double sumErl = 0;

            for (int j = 0; j <= V; j++)
            {
                sumErl += Math.Pow(Erl, j) / factorial(j);
            }

            double pi = (Math.Pow(Erl, i) / factorial(i)) / sumErl;

            return pi;
        }

    }
}