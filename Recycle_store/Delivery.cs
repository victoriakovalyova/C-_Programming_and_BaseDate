using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recycle_store
{
    public partial class Delivery : Form
    {
        public string id;
        public int t;
        public double cost;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        public Delivery(string name, int type, double c)
        {
            InitializeComponent();
            id = name;
            t = type;
            cost = c;
            label3.Text += cost;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime time = date.Value;
            string queryString2;
            string mas;
            if (t == 2){
                queryString2 = $"INSERT INTO Facilities ( Cost, Adress, Time_, id_t, id_order) VALUES ( {cost}, @adres, @time, {t}, @order)";
                
                mas = "Доставка успешно оформлена";
            }
            else {
                queryString2 = $"INSERT INTO Facilities ( Cost, Adress, Time_, id_t, id_bas) VALUES ( {cost}, @adres, @time, {t}, @order)";
                mas = "Транспортировка успешно оформлена";
            }

            if (adres.Text != "" && date.Value != null && id != "")
            {
                
                cmd = new SqlCommand(queryString2, connection);
                cmd.Parameters.AddWithValue("@order", int.Parse(id));
                cmd.Parameters.AddWithValue("@adres", adres.Text);
                cmd.Parameters.AddWithValue("@time", time);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(mas);
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
            this.Close();
        }
    }
}
