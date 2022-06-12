
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Окно_Лаба_1_
{
    class DBwork
    {   
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root;database=gamessite;SSL Mode=None");//port=3306
        // SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-K33HN97\SQLEXPRESS;Initial Catalog=IT-otdel;Integrated Security=True");
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();

        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }

}
