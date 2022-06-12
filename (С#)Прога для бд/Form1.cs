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
    public partial class Form1 : Form
    {
        int w = 0;
        int i = 0;
        int y = 0;
        int u1;
        int u = 0;//Это и выше - шляпа для удачного прохода по Введите Н из Таблицы неизвестное колво раз
        int q = 1;//количество проходов по колонкам пустой строки для ее заполнения в ГРИДЕ
        DBwork db = new DBwork();//подключаем бд
        DataTable table1 = new DataTable();
        DataTable table = new DataTable();//имена таблиц
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//закрытие
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Hide();
            button2.Hide();
            label2.Hide();

            label1.Text = "Выберите таблицу, в которую хотите добавить данные:";

            MySqlCommand command = new MySqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'GAMESSITE'", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);//тут имена таблиц

            dataGridView1.DataSource = table;//момент когда буфер табле идет в таблицу grid
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)// -2 = иначе он допишет пустую ячейку(это  имя таблицы с диаграммами и пустая строка - то есть если написать -1 = мы увидим все таблицы 
            {
                string d = dataGridView1.Rows[i].Cells[2].Value.ToString(); 
                comboBox1.Items.Add(d);
            }



        }

        private void button2_Click(object sender, EventArgs e)//подтверждаем vvod
        {
            String item3 = " ";//имя колонки для update
            String item2 = " ";//имя столбца ключа
            DBwork db = new DBwork();
            if (comboBox1.SelectedItem != null)
            {
                if (u < u1-1)
                {

                    label2.Show();
                    label1.Hide();
                    //button2.Hide();
                    comboBox1.Hide();
                    textBox1.Show();
                    button3.Hide();
                    if (u < u1 - 2)
                        label2.Text = "Введите новое значение " + dataGridView2.Columns[i + 2].HeaderText + " для таблицы " + comboBox1.SelectedItem + " :";
                    i++;
                    ///////Сделать чтобы ТАБЛИА ГРИД1 давала все в БД. Окно красиво заканчивало процесс.
                    int o = dataGridView2.Rows.Count - 1;//индекс пустой строки в конце.          
                    dataGridView2.Rows[o].Cells[q].Value = textBox1.Text;

                    item2 = dataGridView2.Columns[0].HeaderText;
                    item3 = dataGridView2.Columns[q].HeaderText;//Имя колонки
                    int A = dataGridView2.Rows.Count - 2;//Именно адрес последней заполненой строки -1 даст пустую 
                    int item = Convert.ToInt32(dataGridView2.Rows[A].Cells[0].Value) + 1;
                    if (w == 0)
                    {
                        String item4 = dataGridView2.Columns[0].HeaderText;//Имя колонки
                        db.openConnection();
                        MySqlCommand command = new MySqlCommand("INSERT INTO " + comboBox1.SelectedItem + " ("+item4+"," +item3+") VALUES ("+ item +",'" + textBox1.Text + "')", db.getConnection());
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        w++;
                    }
                    else
                    { 
                        
                        MySqlCommand command = new MySqlCommand("UPDATE [" + comboBox1.SelectedItem + "] SET [" + item3 + "] = '" + textBox1.Text + "' WHERE [" + item2 + "] = '"+ item +"' ", db.getConnection());
                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                    }
                    q++;//сдвиг по колонкам вправо  
                    if (u == u1 - 2)//Когда мы зайдем сюда последний раз (нажмем на кнопку у последнего столбца таблицы)
                    {
                        MessageBox.Show("Данные добавлены в таблицу", "Уведомление");
                        Form1 FM2 = new Form1();
                        FM2.ShowDialog();
                        this.Close();
                    }
                    u++;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DBwork db = new DBwork();
            if (y == 0 && comboBox1.SelectedItem != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM " + comboBox1.SelectedItem + "", db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table1);//сюда запихиваем таблицу которую выбрали

                dataGridView2.DataSource = table1;//тупо удобный буфер
                u1 = dataGridView2.Columns.Count;
                y++;

            }
            if (comboBox1.SelectedItem != null)
            {
                if (u < u1)
                {
                    label2.Show();
                    label1.Hide();
                    button2.Show();
                    comboBox1.Hide();
                    textBox1.Show();
                    button3.Hide();

                    label2.Text = "Введите новое значение " + dataGridView2.Columns[i+1].HeaderText + " для таблицы " + comboBox1.SelectedItem + " :";
                   
                }
            }
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//Выбираем таблицу
        {

        }
    }
}
