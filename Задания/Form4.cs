using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using bibliotekaa;

namespace Задания
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection();
        string id_stroki;

        private void Form4_Load(object sender, EventArgs e)
        {
            string connStr = "server=caseum.ru;port=33333;user=test_user;" +
                "database=db_test;password=test_pass;";
            conn = new MySqlConnection(connStr);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentRow.Selected = true;
                string index_stroki;
                index_stroki = dataGridView1.SelectedCells[0].RowIndex.ToString();
                id_stroki = dataGridView1.Rows[Convert.ToInt32(index_stroki)].Cells[2].Value.ToString();
                DateTime todays_date = DateTime.Today;
                DateTime Date_of_Birth = Convert.ToDateTime(dataGridView1.Rows[Convert.ToInt32(index_stroki)].Cells[2].Value.ToString());
                string result = (todays_date - Date_of_Birth).ToString();
                MessageBox.Show("С даты дня рождения прошел" + result.Substring(0, result.Length - 9) + "день");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"Выбор айди студента, ФИО студента, выбор дня студента";
            try
            {
                conn.Open();
                //Запрос в соединение conn.
                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, conn);
                DataSet dataset = new DataSet();
                IDataAdapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
                //Направояем dataGridView1 в правильное русло.
            }
            catch
            {
                MessageBox.Show("База данных не подключена");
                //Сообщение о состоянии соединения.
            }
            finally
            {
                conn.Close();
                //Закрываем соединение.
            }
        }
    }
}
