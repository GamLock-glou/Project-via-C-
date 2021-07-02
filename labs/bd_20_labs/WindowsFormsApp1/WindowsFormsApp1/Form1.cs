using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;

        string sql = "SELECT * FROM Customers";

        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.connectionString;

            using (con)
            {
                con.Open();
                adapter = new SqlDataAdapter(sql, con);

                ds = new DataSet();
                adapter.Fill(ds);
                // В конструкторе данные загружаются в DataSet, первая таблица которого устанавливается в качестве источника данных для dataGridView1:

                dataGridView1.DataSource = ds.Tables[0];

            }
        }


            private void button1_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            ds.Tables[0].Rows.Add(row);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.connectionString;
            using (con)
            {
                con.Open();
                adapter = new SqlDataAdapter(sql, con);
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }

                adapter.DeleteCommand = new SqlCommand("DELETE FROM Customers WHERE CustomerID = @CustomerID", con);

                adapter.DeleteCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Char, 5, "CustomerID"));

                adapter.Update(ds);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.connectionString;
            using (con)
            {
                con.Open();
                adapter = new SqlDataAdapter(sql, con);

                adapter.InsertCommand = new SqlCommand("INSERT INTO Customers (CustomerID, CompanyName) " +
        "VALUES (@CustomerID, @CompanyName)", con);

                adapter.InsertCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Char, 5, "CustomerID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.VarChar, 40, "CompanyName"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@oldCustomerID", SqlDbType.Char, 5, "CustomerID"));
                adapter.Update(ds);
            }

        }
    }
}
