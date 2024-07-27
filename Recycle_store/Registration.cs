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
    public partial class Registration : Form
    {
        public SqlConnection connection = new
SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public SqlDataAdapter adapter;
        public SqlCommand cmd;

        public Registration()
        {
            InitializeComponent();
        }
        public void DisplayClientData(DataGridView dataGrid)
        {
            connection.Open();
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter("select * from client", connection);
            adapter.Fill(dt);
            dataGrid.DataSource = dt;
            connection.Close();
        }
        public void AddClient(string name, string lastName, string midName, DateTime dateOfBirth, string phone, string organization) //DataGridView dataGrid)
        {
            if (name != "" && lastName != "" && midName != "" && dateOfBirth != null && phone != "" && organization != "")
            {
                //cmd = new SqlCommand("INSERT INTO Client (Last_Name, First_name, Middle_name, DOB, Organization) VALUES(@lastName, @name, @midName, @date, @organization)", connection);
                cmd = new SqlCommand("INSERT INTO Client(Last_Name, First_Name, Middle_Name, DOB, Telephone, Organization) VALUES(@lastName, @name, @midName, @date, @phone, @organization)", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@name", name); 
                cmd.Parameters.AddWithValue("@midName", midName);
                cmd.Parameters.AddWithValue("@date", dateOfBirth);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@organization", organization);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Клиент добавлен");
                //DisplayClientData(dataGrid);
                //ClearData();
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }

        private void buttonRegistration_Click(object sender, EventArgs e) => AddClient(FirstName.Text, LastName.Text, MidleName.Text, DOB.Value, Phone.Text, Organization.Text);
    }
}
