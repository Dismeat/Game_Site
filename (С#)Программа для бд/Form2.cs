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
    public partial class Form2 : Form
    {
        String D = " ";
        int w = 0;
        int i = 0;
        int y = 0;
        int u1;
        int u = 0;//Это и выше - шляпа для удачного прохода по Введите Н из Таблицы неизвестное колво раз
        DBwork db = new DBwork();//подключаем бд
        DataTable table1 = new DataTable();
        DataTable table = new DataTable();//имена таблиц
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//закрытие
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Hide();
            button2.Hide();
            label2.Hide();
            comboBox2.Hide();
            comboBox3.Hide();
            label1.Text = "Выберите таблицу, в которой хотите изменить данные:";

            MySqlCommand command = new MySqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'GAMESSITE'", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);//тут имена таблиц

            dataGridView1.DataSource = table;//момент когда буфер табле идет в таблицу grid
            for (int i = 0; i < dataGridView1.Rows.Count - 2; i++)// -2 = иначе он допишет пустую ячейку(это имя таблицы с диаграммами и пустая строка - то есть если написать -1 = мы увидим все таблицы 
            {
                string d = dataGridView1.Rows[i].Cells[2].Value.ToString();
                comboBox1.Items.Add(d);
            }
        }

        private void button2_Click(object sender, EventArgs e)//подтверждаем vvod
        {
            String item3 = " ";//имя колонки для update
            String item2 = " ";//имя столбца ключа
            int w1 = 0;
            DBwork db = new DBwork();
            if (comboBox1.SelectedItem != null)
            {
                if (u < u1 )// Мы сюда зайдем N-1 раз от колва столбцов 
                {
                    label2.Show();
                    label1.Hide();
                    button2.Show();
                    comboBox1.Hide();
                    comboBox2.Hide();
                    comboBox3.Hide();
                    textBox1.Show();
                    button3.Hide();

                    String y = comboBox2.SelectedItem.ToString();//номер ключа строки которую редачим

                    foreach (DataGridViewRow row in dataGridView2.Rows)//Циклично чекаем каждую строку Grid1
                    {
                        if (row.Cells[0].Value.ToString() == comboBox2.SelectedItem.ToString())
                        {
                            w1 = Convert.ToInt32(row.Index.ToString());//Номер строки ИМЕННО 
                            break;
                        }
                    }
                    if (u < u1-1)// Мы сюда зайдем N-1 раз от колва столбцов 
                    {
                        D = dataGridView2.Rows[w1].Cells[u + 1].Value.ToString();//Сразу со 2 ячейки в строке идем(ключи не трогаем)
                        label2.Text = "Введите новое значение " + dataGridView2.Columns[u + 1].HeaderText + " или оставьте текущее :";
                    }

                    item2 = dataGridView2.Columns[0].HeaderText;//имя столбца ключа
                    item3 = dataGridView2.Columns[u].HeaderText;//Имя колонки(u - потому что в первый раз пропускаем)

                    if(u>0)//2 нажатие на кнопку по делу
                    {
                        MySqlCommand command = new MySqlCommand("UPDATE [" + comboBox1.SelectedItem + "] SET [" + item3 + "] = '" + textBox1.Text + "' WHERE [" + item2 + "] = '" + y + "' ", db.getConnection());
                        // Обновить таблицу КОМБО1 заменить в Столбце который мы рассматривали значение на значение ТЕКСТБОХ1 , где в столбце 0(ключи) значение ключа равно Рассматриваемому
                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                    }
                    textBox1.Text = D; //Записываем то что в ячейке сюд
                }
                if (u == u1 - 1)//Когда мы зайдем сюда последний раз (нажмем на кнопку у последнего столбца таблицы)
                {
                    MessageBox.Show("Данные в таблице отредактированы", "Уведомление");
                    Form2 FM2 = new Form2();
                    FM2.ShowDialog();
                    this.Close();
                }
                u++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DBwork db = new DBwork();
            if ( comboBox1.SelectedItem != null)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM " + comboBox1.SelectedItem + "", db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table1);//сюда запихиваем таблицу которую выбрали

                dataGridView2.DataSource = table1;//тупо удобный буфер
                u1 = dataGridView2.Columns.Count;
                

                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    //Берем цифорки ключей из 1 столбца каждой строки в ДАТАГРИД2
                    string d = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    comboBox2.Items.Add(d);
                }

                label2.Show();
                label1.Hide();
                comboBox2.Show();
                comboBox1.Hide();
                button3.Hide();
                button2.Show();

                label2.Text = "Выберите Ключ строки таблицы " + comboBox1.SelectedItem + " для редактирования :";

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}