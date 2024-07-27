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
using System.Windows.Input;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.CheckedListBox;

namespace Recycle_store
{
    public partial class Main : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public int id_client;
        SqlDataAdapter adapter;
        public CheckedItemCollection codes;
        public CheckedItemCollection products;
        public int count;
        public CheckedItemCollection orders;
        public int hash;
        public string order;
        SqlCommand cmd = new SqlCommand();
        public string fraction;
        //public CheckedItemCollection adreses;
        public string adres;
        public string bas;
        public List<string> person = new List<string>();
        public double cost = 500;

        public Main(int id)
        {
            
            InitializeComponent();
            id_client = id;
            openDate(id_client);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            person.Clear();
        }

        void openDate(int id)
        {
            string queryString1 = "SELECT Last_Name, First_Name, Middle_Name, Telephone, DOB, Organization FROM Client WHERE id_client = @id;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand command1 = new SqlCommand(queryString1, connection);
                command1.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (SqlDataReader reader = command1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        person.Add(reader.GetString(0));
                        textBox1.Text = reader.GetString(0);
                        person.Add(reader.GetString(1));
                        textBox2.Text = reader.GetString(1);
                        person.Add(reader.GetString(2));
                        textBox3.Text = reader.GetString(2);
                        textBox4.Text = reader.GetString(3);
                        dateTimePicker1.Value = reader.GetDateTime(4);
                        textBox5.Text = reader.GetString(5);
                    }
                }
                if (id_client == 1032)
                {
                    cost *= 0.5;
                }

            }
           
            string queryString2 = "SELECT QR_code.Type FROM Client FULL JOIN QR_code ON Client.id_QR_code = QR_code.id_QRcode WHERE Telephone = (SELECT Telephone FROM Client WHERE Client.id_client = @id);";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand command2 = new SqlCommand(queryString2, connection);
                command2.Parameters.AddWithValue("@id", id);
                connection.Open();


                using (SqlDataReader reader = command2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        checkedListBox1.Items.Add(reader[0].ToString());
                    }
                    reader.Close();

                }
                connection.Close();
                codes = checkedListBox1.CheckedItems;

            }

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string queryString = "UPDATE Client SET Last_Name = @lastname," +
                " First_Name = @firstname," +
                " Middle_Name = @midlename, " +
                "Telephone = @phone," +
                " DOB = @date, " +
                "Organization = @company " +
                "WHERE id_client = @id";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", id_client);
                command.Parameters.AddWithValue("@firstname", textBox2.Text);
                command.Parameters.AddWithValue("@lastname", textBox1.Text);
                command.Parameters.AddWithValue("@midlename", textBox3.Text);
                command.Parameters.AddWithValue("@phone", textBox4.Text);
                command.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                command.Parameters.AddWithValue("@company", textBox5.Text);
                command.ExecuteNonQuery();
                connection.Close();
            }
            MessageBox.Show("Данные успешно изменены!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string queryString = "DELETE FROM Client WHERE id_client = @id;";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", id_client);
                command.ExecuteNonQuery();
                connection.Close();
            }
            MessageBox.Show("Аккаунт успешно удален!");
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //OleDbDataAdapter adapter = new OleDbDataAdapter();
            string queryString = "SELECT Product, Counter_, Description_ FROM STORE FULL JOIN " +
                "QR_code ON STORE.id_code = QR_code.id_QRcode WHERE STORE.id_code = " +

                "(SELECT QR_code.id_QRcode FROM QR_code WHERE QR_code.Type = @type );"; //(SqlDbType.NChar)codes[0].ToString().Trim()); ; ;

            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@type", codes[0].ToString());
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    checkedListBox2.Items.Add(String.Format("{0} {1} {2}", reader[0].ToString(), reader[1].ToString(), reader[2].ToString()));
                }
                reader.Close();

            }
            connection.Close();
            products = checkedListBox2.CheckedItems;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            foreach (var item in products)
            {
                checkedListBox3.Items.Add(item.ToString());
            }


            orders = checkedListBox3.CheckedItems;
        }

        public void DisplayClientData(DataGridView dataGrid, string cm)
        {
            connection.Open();
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter(cm, connection);
            adapter.Fill(dt);
            dataGrid.DataSource = dt;
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
        
            string queryString1 = "INSERT INTO Orders (id_p, Number, Counter_, Time_) VALUES  (@id_per, @numb, @c, @time)";
            hash = Math.Abs(DateTime.UtcNow.GetHashCode());
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString1, connection);
                command.Parameters.AddWithValue("@id_per", id_client);
                command.Parameters.AddWithValue("@numb", hash);
                command.Parameters.AddWithValue("@c", 1);
                command.Parameters.AddWithValue("@time", DateTime.UtcNow);
                command.ExecuteNonQuery();
                connection.Close();

            }

            //label9.Text = FindProduct(orders[0].ToString());
            string query = $"SELECT *FROM Orders WHERE id_p = {id_client} ";
            DisplayClientData(Orders, query);


            string queryString2 = "INSERT INTO Order_list ( id_per, id_st, id_or) VALUES (@per, @st, @or )";
            foreach (var item in orders)
            {
                string prod = item.ToString().Substring(0, 49).Trim();
                ;
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(queryString2, connection);
                    //command.Parameters.AddWithValue("@pos", item);
                    command.Parameters.AddWithValue("@or", FindOrder(hash));
                    command.Parameters.AddWithValue("@st", FindProduct(prod));
                    command.Parameters.AddWithValue("@per", id_client);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            MessageBox.Show("Данные успешно добавлены!");

        }

        //Находит айти товара в катлоге товара по наименованию
        public int FindProduct(string name)
        {
            string C = "SELECT id_product FROM STORE WHERE Product = @name;";
            SqlCommand command = new SqlCommand(C, connection);
            command.Parameters.AddWithValue("@name", name);
            connection.Open();
            int i = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    i = reader.GetInt32(0);
                    //count = reader.GetInt32(1);
                }
                reader.Close();

            }
            connection.Close();
            return i;
            //MessageBox.Show("Нашел!");
        }

        //Находит айди заказа в заказах по номеру заказа, переведенный в хеш номер
        public int FindOrder(int hash)
        {
            string C = "SELECT id_Order FROM Orders WHERE Number = @hash;";
            SqlCommand command = new SqlCommand(C, connection);
            command.Parameters.AddWithValue("@hash", hash);
            connection.Open();
            int n = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    n = reader.GetInt32(0);
                }
                reader.Close();

            }
            connection.Close();
            return n;
        }

        private void Orders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            order = Orders.Rows[e.RowIndex].Cells[0].Value.ToString();
            string query = $"SELECT STORE.Product, STORE.Counter_ FROM Order_list LEFT JOIN STORE ON (Order_list.id_st = STORE.id_product) WHERE Order_list.id_or = {order} ";
            DisplayClientData(Order_list, query);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery(order, 2, cost);
            delivery.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            connection.Open();
            if (order != "")
            {
                cmd = new SqlCommand("delete from Orders where id_Order = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", int.Parse(order));
                cmd.ExecuteNonQuery();
                        
                        MessageBox.Show("Заказ был успешно отменен!");
                    }
                    else
                    {
                        MessageBox.Show("Не выбран заказ");
                    }
            connection.Close();
            string query = $"SELECT *FROM Orders WHERE id_p = {id_client} ";
            DisplayClientData(Orders, query);
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            string query1 = $"SELECT *FROM Orders WHERE id_p = {id_client} ";
            DisplayClientData(Orders, query1);
            string query2 = "SELECT id_fraction, Name_, Description_, Type_, QR_code.Type AS QR_code FROM Fraction LEFT JOIN QR_code ON (Fraction.code = id_QRcode)";

            select_fraction(query2);
            //DisplayClientData(fractions, query2);

            select_map();
            string query3 = $"SELECT BASKET.id_basket, Number, Volume, Fraction.Name_ , MAP.Adres " +
                $"FROM BASKET LEFT JOIN Fraction ON (Fraction.id_fraction = BASKET.id_frac) " +
                $"LEFT JOIN MAP ON (MAP.id_adres = BASKET.id_ad) WHERE client = {id_client};";
            DisplayClientData(basket, query3);
        }



        public void select_map()
        {
            string queryString = "SELECT Adres FROM MAP";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand command2 = new SqlCommand(queryString, connection);
                connection.Open();


                using (SqlDataReader reader = command2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader[0].ToString());
                    }
                    reader.Close();

                }
                connection.Close();

            }
        }

        public void select_fraction(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand command2 = new SqlCommand(queryString, connection);
                connection.Open();


                using (SqlDataReader reader = command2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader[1].ToString());
                    }
                    reader.Close();

                }
                connection.Close();

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hash = Math.Abs(DateTime.UtcNow.GetHashCode());
            adres = comboBox1.Text.ToString();
            fraction = comboBox2.Text.ToString();
            
            string queryString2 = "INSERT INTO BASKET (Number, Volume, id_ad, id_frac, client) VALUES(@numb, @volume, @adres, @fraction, @c )";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                if (textBox6.Text != "" && id_client != 0 && adres != "")
                {
                    connection.Open();
                    cmd = new SqlCommand(queryString2, connection);
                    cmd.Parameters.AddWithValue("@numb", hash.ToString());
                    cmd.Parameters.AddWithValue("@volume", textBox6.Text);
                    cmd.Parameters.AddWithValue("@adres", FindAdres(adres));
                    cmd.Parameters.AddWithValue("@fraction", FindFraction(fraction));
                    cmd.Parameters.AddWithValue("@c", id_client);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Обмен совершен!");
                }
                else
                {
                    MessageBox.Show("Введите данные");
                }
                connection.Close();
            }

                string query2 = $"SELECT Number, Volume, Fraction.Name_ ,MAP.Adres " +
                    $"FROM BASKET LEFT JOIN Fraction ON (Fraction.id_fraction = BASKET.id_frac) " +
                    $"LEFT JOIN MAP ON (MAP.id_adres = BASKET.id_ad) WHERE client = {id_client};";
                DisplayClientData(basket, query2);
            
        }

        //Находит айти товара в катлоге товара по наименованию
        public int FindAdres(string name)
        {
            string C = "SELECT id_adres FROM MAP WHERE Adres = @name;";
            
            SqlCommand command = new SqlCommand(C, connection);
            command.Parameters.AddWithValue("@name", name);
            connection.Open();
            int i = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    i = reader.GetInt32(0);
                    //count = reader.GetInt32(1);
                }
                reader.Close();

            }
            connection.Close();
            return i;
            //MessageBox.Show("Нашел!");
        }

        public int FindFraction(string name)
        {
            string C = "SELECT id_fraction FROM Fraction WHERE Name_ = @name;";
            SqlCommand command = new SqlCommand(C, connection);
            command.Parameters.AddWithValue("@name", name);
            connection.Open();
            int i = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    i = reader.GetInt32(0);
                    //count = reader.GetInt32(1);
                }
                reader.Close();

            }
            connection.Close();
            return i;
            //MessageBox.Show("Нашел!");
        }


        private void button9_Click(object sender, EventArgs e)
        {
            Delivery trans = new Delivery(bas, 1, cost);
            trans.Show();
        }

        private void basket_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bas = basket.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        public void ExportExcel(DataGridView dataGrid)
        {
            Microsoft.Office.Interop.Excel._Application app = new
            Microsoft.Office.Interop.Excel.Application();
            // создаем новый WorkBook
            Microsoft.Office.Interop.Excel._Workbook workbook =
            app.Workbooks.Add(Type.Missing);
            // новый Excelsheet в workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Лист1"];
            worksheet = workbook.ActiveSheet;
            // задаем имя для worksheet
            worksheet.Name = "Exported from gridview";
            for (int i = 1; i < dataGrid.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGrid.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] =
                    dataGrid.Rows[i].Cells[j].Value.ToString();
                }
            }
            // закрываем подключение к excel
            app.Quit();
        }

        public void ExportWord(DataGridView DGV)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];
                //добавим поля и колонки
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    }
                }
                Microsoft.Office.Interop.Word.Document oDoc = new
                Microsoft.Office.Interop.Word.Document();
                oDoc.Application.Visible = true;
                //страницы
                oDoc.PageSetup.Orientation =
                Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;
                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";
                    }
                }
                //формат таблиц
                oRange.Text = oTemp;
                object Separator =
                Microsoft.Office.Interop.Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior =
                Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                Type.Missing);
                oRange.Select();
                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                //Стили заголовков
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {

                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }
                //Текст заголовка
                foreach (Microsoft.Office.Interop.Word.Section section in
                oDoc.Application.ActiveDocument.Sections)
                {
                    Microsoft.Office.Interop.Word.Range headerRange =
                    section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange,
                    Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Отчет";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment =
                    Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }
            }
        }

        private void button15_Click(object sender, EventArgs e) => ExportExcel(dataGridView1);

        private void button16_Click(object sender, EventArgs e) => ExportWord(dataGridView1);

        private void button14_Click(object sender, EventArgs e) => DisplayClientData(dataGridView1, $"SELECT Number, Counter_, Time_ FROM Orders WHERE id_p = {id_client} ORDER BY Time_ DESC  ");

        private void button13_Click(object sender, EventArgs e) => DisplayClientData(dataGridView1, $"SELECT Number, Volume, MAP.Adres FROM BASKET LEFT JOIN MAP ON (MAP.id_adres = BASKET.id_ad) WHERE client = {id_client} ORDER BY Volume DESC");

        private void button12_Click(object sender, EventArgs e) => DisplayClientData(dataGridView1, $"SELECT Fraction.Name_ AS Фракция,  SUM(Volume) AS Объем FROM BASKET LEFT JOIN Fraction ON (Fraction.id_fraction = BASKET.id_frac) GROUP BY Fraction.Name_ ORDER BY Объем DESC");

        private void button11_Click(object sender, EventArgs e) => DisplayClientData(dataGridView1, $"SELECT  MAP.Adres AS Адрес, COUNT(*) AS Загруженность, SUM(Volume) AS Объем FROM BASKET LEFT JOIN MAP ON (MAP.id_adres = BASKET.id_ad) GROUP BY MAP.Adres ORDER BY Загруженность DESC");
        
    }
}

