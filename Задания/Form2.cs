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

namespace Задания
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        class MySqlCon
        {

            public MySqlConnection connect()
            {
                string connStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
                MySqlConnection conn = new MySqlConnection(connStr);
                return conn;
            }
            public static string host = "caseum.ru";
            public static string port = "33333";
            public static string user_id = "test_user";
            public static string database = "db_test";
            public static string password = "test_pass";


            public static string sqlcon()
            {
                string conn = $"server={host};port={port};user={user_id};database={database};password={password}";
                return conn;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conection = new MySqlConnection(MySqlCon.sqlcon());
            try
            {
                conection.Open();
                MessageBox.Show("Подключение к базе данных выполнено успешно");
            }
            catch
            {
                MessageBox.Show("Не удалось подключится к базе данных((");
                conection.Close();
            }
            finally
            {
            }
        }
    }
}

