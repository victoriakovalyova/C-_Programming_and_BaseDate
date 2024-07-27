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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab1 lab1 = new Lab1();
            lab1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab2 lab2 = new Lab2();
            lab2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lab3 lab3 = new Lab3();
            lab3.Show();
        }
        /*
        private void button4_Click(object sender, EventArgs e)
        {
            Lab4 lab4 = new Lab4();
            lab4.Show();
        }*/

        private void button5_Click(object sender, EventArgs e)
        {
            Lab5 lab5 = new Lab5();
            lab5.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ковалева Виктория Викторовна\nГруппа:бИСТ-225\nДисциплина: " +
                "Теория информационных процессов и систем\nРуководители: Аснина Н.Г. и Барбарош А.А.\nВоронеж 2024\nTellegram:https://t.me/vezhevika2004",
                "Информация об авторе");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Lab4 lab4 = new Lab4();
            lab4.Show();
        }
    }
}
