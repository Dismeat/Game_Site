//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Окно_Лаба_1_
{
    public partial class Form3 : Form
    {
        DBwork db = new DBwork();//подключаем бд
        DataTable table1 = new DataTable();
        DataTable table = new DataTable();
        DataTable table3 = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        public String item = " ";
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//Фильтрация - перадача Массива готового в ДАТАГРИД1
        {
            if (listBox1.SelectedItems.Count != 0)//если 2) выбран то только тогда пашет 
            {
                if (textBox1.Text == "")//Если поле с параметром пустое 2) 
                {
                    int t = listBox1.SelectedIndex;
                    dataGridView1.Sort(dataGridView1.Columns[t], ListSortDirection.Ascending);
                    this.Close(); ;
                }
                else // 1) 2) 
                {

                    //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Цена <=5000";//Это работает и сразу ДАТАГРИД сортируется
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"" + listBox1.SelectedItem.ToString() + " LIKE '%" + textBox1.Text + "%'";
                    this.Close();
                }
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void Form3_Load(object sender, EventArgs e)//При загрузке закидываем столбцы из таблицы с ОСНОВНОЙ формы (передали сюда в 3 форму) в лист
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM " + item + "", db.getConnection());//Таблица из бд
            adapter.SelectCommand = command;
            adapter.Fill(table);//сюда запихиваем таблицу которую выбрали

            dataGridView1.DataSource = table;//тупо удобный буфер

            for (int i = 0; i < dataGridView1.Columns.Count ; i++)
            {
                //Берем цифорки ключей из 1 столбца каждой строки в ДАТАГРИД2
                string d = dataGridView1.Columns[i].HeaderText;
                listBox1.Items.Add(d);
            }

            listBox2.Hide();
            label3.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox2.Show();
            //label3.Show();
        }

    }
}
