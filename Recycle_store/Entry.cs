using Microsoft.Data.Sqlite;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Recycle_store
{
    public partial class Entry : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public string id;
        public int clientid;
        

        public Entry()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            autorise();
        }

        public void autorise()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT id_client FROM Client WHERE Telephone = @phone", connection);
            cmd.Parameters.AddWithValue("@phone", Phone.Text);
            int id = (int)cmd.ExecuteScalar();
            if (id > 0)
            {
                this.Hide();
                Main Person = new Main(id);
                Person.Show();
                object result = cmd.ExecuteScalar();
                id = Convert.ToInt32(result);
                Person.id_client = id;
                //client.tb_FIO_K.Text = (string)cmd2.ExecuteScalar();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль! Попробуйте ещё раз.");
            }
            connection.Close();

        }

    }
}
