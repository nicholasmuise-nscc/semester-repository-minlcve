using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PracticeDatabase
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private DataSet dataSet;
        private bool changesMade = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;password=Sunoo123!;database=testdb;";

            try
            {
                connection = new MySqlConnection(connStr);
                connection.Open();
                lblStatus.Text = "Connected to MySQL database.";
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Connection failed: " + ex.Message;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string query = txtQuery.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Please enter a SQL SELECT query.");
                return;
            }

            try
            {
                adapter = new MySqlDataAdapter(query, connection);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                dataSet = new DataSet();
                adapter.Fill(dataSet, "Results");
                dataGridView1.DataSource = dataSet.Tables["Results"];

                // Enable save on edit
                dataSet.Tables["Results"].ColumnChanged += (s, args) =>
                {
                    changesMade = true;
                    btnSave.Enabled = true;
                };

                lblStatus.Text = "Query loaded. You can now edit and save.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Query failed: " + ex.Message);
            }
        }


        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                connection?.Close();
                lblStatus.Text = "Disconnected from MySQL.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error disconnecting: " + ex.Message;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtQuery_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!changesMade)
            {
                MessageBox.Show("No changes to save.");
                return;
            }

            try
            {
                adapter.Update(dataSet, "Results");
                lblStatus.Text = "Changes saved successfully.";
                btnSave.Enabled = false;
                changesMade = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message);
            }
        }

    }
}
