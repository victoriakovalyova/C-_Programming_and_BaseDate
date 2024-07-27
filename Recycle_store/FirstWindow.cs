using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recycle_store
{
    public partial class FirstWindow : Form
    {
        public FirstWindow()
        {
            InitializeComponent();
        }

        private void FirstWindow_Load(object sender, EventArgs e)
        {

        }

        private void Entry_Click(object sender, EventArgs e)
        {
            Entry entry = new Entry();
            entry.Show();
        }

        private void Registration_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }

        private void Creater_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработала Ковалева В.В. \nГруппа бИСТ-225 \nПо дисциплине Базы данных \nРуководитель Иванов Д.В. \nВоронеж 2024", "Автор работы");
        }
    }
}
