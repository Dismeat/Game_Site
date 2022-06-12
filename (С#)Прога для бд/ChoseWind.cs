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
    public partial class ChoseWind : Form
    {
        DBwork db = new DBwork();//подключаем бд
        DataTable table1 = new DataTable();
        DataTable table = new DataTable();
        DataTable table3 = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();


        //Сверху открываем бд (17) - готовим таблицу для бд(виртуальную) - адаптер (нужен чтобы туда мочь запихнуть то, что найдем по sql запросу)

        public ChoseWind()
        {
            InitializeComponent();//ПАИХАЛИ
        }

        private void ChoseWind_Load_1(object sender, EventArgs e)//Что произойдет после запуска
        {
            button6.Hide();
            //заполняем ниюжнюю таблицу данными из бд
            MySqlCommand command = new MySqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'GAMESSITE'", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataGridView2.DataSource = table;//момент когда буфер табле идет в таблицу grid
            for(int i=0;i<dataGridView2.Rows.Count-1;i++)// -1 = иначе он допишет пустую ячейку(имя таблицы с диаграммами и строка имен столбцов(она тут  почему-то идет последней)
            {
                //dataGridView2.
                string d = dataGridView2.Rows[i].Cells[2].Value.ToString();
                //MessageBox.Show("" + d + ""); //Это чтобы проверить имена таблиц которые записываются .
                checkedListBox2.Items.Add(d, 0);
            }
        }

        //Выпадающий список таблиц из базы данных
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Если отмечено больше 1 элементa, то снимаем выделение со всех и отмечаем текущий.
            if (checkedListBox2.CheckedItems.Count > 0)
            {
                for (int i=0; i < checkedListBox2.Items.Count; i++)
                    checkedListBox2.SetItemChecked(i, false);
                checkedListBox2.SetItemChecked(checkedListBox2.SelectedIndex, true);
            }
            //индекс всего один выбирается - indexChecked.ToString() - цифры - itemChecked.ToString() - текст
        }



        //Жму на кнопку(выбор таблицы и срабатывает ниже)
        private void button1_Click(object sender, EventArgs e)
        {
            table1.Columns.Clear();//чистка предыдущей таблицы из буфера
            table1.Rows.Clear();
            dataGridView1.Columns.Clear();//чистка самой таблицы(тут есть только чекбоксы - удаляем чтобы не дублировались)

            /* table1 = буфер, в котором записано что мы туда заносили. Поэтому
             каждый раз обнуляем по строкам и столбцам(просто clear почему-то 
            удаляет только строки. 
               Каждый раз table1 динамически расширяется, без очистки - одни данные 
            наложатся на другие.Причем зеркально(строки). Столбцы по порядку (первого 
            потом второго).
            */

            if (checkedListBox2.CheckedItems.Count != 0)//Если не выбран флажок на имени таблицы то не зайдем
            {
                String item = " ";//Переменная для имени таблицы
                foreach (object itemChecked in checkedListBox2.CheckedItems)
                {
                    item = itemChecked.ToString();//Зашли в кнопку и передали в локальный item переменную из списка checkboxlist
                }

                MySqlCommand command = new MySqlCommand("SELECT * FROM " + item + "", db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table1);//сюда запихиваем все элементы которые дала команда выше
                adapter.Fill(table3);

                dataGridView1.DataSource = table1;
                dataGridView3.DataSource = table3;

                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();//Создаем чекбоксы Delete
                checkBoxColumn.HeaderText = "";
                checkBoxColumn.Width = 30;
                checkBoxColumn.Name = "checkBoxColumn";
                dataGridView1.Columns.Insert(0, checkBoxColumn);

            }
        }




        private void button2_Click(object sender, EventArgs e)// кнопка закрытия - крест
        {
            this.Close();
        }


        Point lastPoint; //Это и ниже чтобы моно было двигать окно
        private void ChoseWind_MouseMove(object sender, MouseEventArgs e)//Движение мышью
        {
            if(e.Button == MouseButtons.Left)//значит зажата Кнопка (левая)
            {
                this.Left += e.X - lastPoint.X;// X = координата по х
                this.Top += e.Y - lastPoint.Y;// po Y
            }
        }

        private void ChoseWind_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }



        private async void button4_Click(object sender, EventArgs e)//Delete
        {
            DBwork db = new DBwork();
            int p = 0;
            int p1 = 0;
            String item1 = " ";//тут номер id
            String item2 = " ";//Имя столбца с номерами
            String item = " ";//тут название таблицы
            foreach (object itemChecked in checkedListBox2.CheckedItems)
            {
                item = itemChecked.ToString();
            }
            int i = 0;
            int[] massa = new int[100]; // Чтобы удалить из ДАТАГРИДА сразу после операции и не надо было обновляться через бд ДАТАГРИД
           //MessageBox.Show("" + item + "");//Проверить ту ли таблицу берет
            item2 = dataGridView1.Columns[1].HeaderText;//имя столбца с ключами
            //MessageBox.Show("" + item2 + "");//То ли имя столбца
            foreach (DataGridViewRow row in dataGridView1.Rows)//Циклично чекаем каждую строку Grid1
            {
                
                bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);// берется 1 столбец на каждой строке по имени столбца "checkBoxColumn"
                if (isSelected)//если галочка есть
                {
                    item1 = row.Cells[1].Value.ToString();//номера на удаление.
                    if (p == 0)
                    {
                        DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить данные из таблицы?",
                       "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //YESNO - записывается в result 
                        if (result == DialogResult.Yes)
                        {
                            p1 = 1;//Значит что надо удалить из БД строки и вывести что  "Данные удалены"
                        }
                    }
                    if (p1==0){
                    row.Cells["checkBoxColumn"].Value = 0;//снимаем галки
                    }
                    if(p1==1){ //значит p1=1 и мы согласились на удаление

                        MySqlCommand command = new MySqlCommand("DELETE FROM ["+item+"] WHERE ["+item2+"] = '"+item1+"'", db.getConnection());
                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        massa[i] = Convert.ToInt32(row.Index.ToString()); 
                        i++;
                    }
                    p = 1;//Больше мы не спрашивает нужно ли удалить данные
                }
            }
            if (p == 0)//Если p=0 значит мы ни нашли ни одной галочки и ничего не выбрано
            {
                MessageBox.Show("Вы ничего не выбрали.", "Уведомление", MessageBoxButtons.OK);
            }
            else if (p1 == 0)
            {
                MessageBox.Show("Данные не удалены.", "Уведомление", MessageBoxButtons.OK);
            }
            else { //Значит человек согласился (p1=1 и мы нашли галочки p=1)
                button1.PerformClick();//обновляет все вызово кнопки
                MessageBox.Show("Данные удалены.", "Уведомление", MessageBoxButtons.OK);
            }
        }




        private void button5_Click(object sender, EventArgs e)//Добавить строку вручную
        {
            this.Hide();//прячем окно первое
            Form1 FM1 = new Form1();
            FM1.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)//Редактирование
        {
            this.Hide();//прячем окно первое
            Form2 FM2 = new Form2();
            FM2.ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)//Фильтр
        {
            if (checkedListBox2.CheckedItems.Count > 0)//фильтр сработает как только передадим имя таблицы
            {
                this.Hide();//прячем окно первое
                Form3 FM3 = new Form3();
                String item = " ";
                foreach (object itemChecked in checkedListBox2.CheckedItems)
                {
                    item = itemChecked.ToString();
                }
                //item а Форме 3 надо обьявить как public
                FM3.item = item; // Передаем в ITEM в форме 3 значение из ЧеклистБОха
                FM3.ShowDialog();
                this.Show();
                dataGridView1.DataSource = FM3.dataGridView1.DataSource;
            }
        }


        private void button3_Click(object sender, EventArgs e)//Сохранить новые данные в БД о таблице 
        {

            MySqlCommandBuilder cmdb1 = new MySqlCommandBuilder(adapter);//заливаем в переменную Билдера наши команды(из адаптера)
            adapter.Update(table1);//теперь эти команды обновляют буфер табле1 который не менялся(менялась лишь gridview1)
            table1.AcceptChanges();//фиксируем stonks отправляя table один обратно в БД
            MessageBox.Show("Изменения сохранены в базе данных", "Уведомление");

        }

        private void button6_Click(object sender, EventArgs e)//Редактирование уже существвующих
        {
            DBwork db = new DBwork();
            String item1 = " ";//сам ключ
            String item3 = " ";//имя колонки для update
            String item4 = " ";// ТО ЧТО МЫ ТУТ И РЕДАКТИРОВАЛИ
            String item2 = " ";//имя столбца ключа
            String item = " ";//тут название таблицы
            foreach (object itemChecked in checkedListBox2.CheckedItems)
            {
                item = itemChecked.ToString();
            }
            item2 = dataGridView1.Columns[1].HeaderText;
            int o = dataGridView1.Rows.Count;
            int o1 = 0;
            int b = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)//каждую строку берем
            {
                if (o1 < o - 1)//потому что в конце ДАТАГРИД добавляет пустую строку
                {
                    item1 = row.Cells[1].Value.ToString();//номера  (Primary key из таблицы в БД)
                    int z = 0;
                    
                    if (Convert.ToInt32(row.Cells[1].Value) != Convert.ToInt32(dataGridView3.Rows[b].Cells[0].Value.ToString()))//Датагрид выдает индексы при любом раскладе и поэтому ТОИНТ
                    {           //строка row и ячейка 1( помним что у нас еще чекбоксы)            строка b и ячейка 0(нет чекбоксов)
                        z++;
                    }
                    foreach (DataGridViewColumn columns in dataGridView1.Columns)//Так как колво колонок может быть анрил большим 
                    {
                        if (z > 1)
                        {
                            int i2 = Convert.ToInt32(columns.Index.ToString());//текущий индекс ячейки в которой мы находимся на строке row +2 так как пропускаем primary key и чекбоксы

                            item3 = dataGridView1.Columns[i2].HeaderText;//Имя колонки
                            item4 = row.Cells[i2].Value.ToString();
                            
                            MySqlCommand command = new MySqlCommand("UPDATE [" + item + "] SET [" + item3 + "] = '" + item4 + "' WHERE [" + item2 + "] = '" + item1 + "' ", db.getConnection());
                            db.openConnection();
                            command.ExecuteNonQuery();
                            db.closeConnection();
                        }
                        z++;
                    }
                    o1++;
                }
                b++;

            }
            MessageBox.Show("Отредактированные элементы сохранены в базе данных", "Уведомление");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //костыль чтобы брать данные для checboxa имен таблиц всей бд - расширить окно с кнопками и она там рядом спрятана
        }
        //Лишняя фигня,которая нужна,чтобы блоки на окне жили(таблица сбоку,задний фон )
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

    }
}
