using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Model.Data;
using Model.Business;
using System.Data;

namespace Model.Data
{
    public class Dbal
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public Dbal(string database, string uid = "root", string password = "5MichelAnnecy", string server = "localhost")
        {
            Initialize(database, uid, password, server);
        }

        private void Initialize(string database, string uid, string password, string server)
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }


        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void ExectQuery(string query)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //pour éxécuter:
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Insert(string query)
        {
            string query2 = "INSERT INTO " + query;
            Console.WriteLine(query2);
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query2, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        public void Update(string query)
        {
            string query2 = "UPDATE " + query ;
            Console.WriteLine(query2);
            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query2;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        public void Delete(string query)
        {
            string query2 = "DELETE FROM " + query;
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query2, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        private DataSet RQuery(string query)
        {
            DataSet dataset = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            adapter.Fill(dataset);
            return dataset;
        }
        public DataTable SelectAll(string table)
        {
            return this.RQuery("select * from " + table).Tables[0];
        }
        public DataTable SelectByField(string table, string fieldTestCondition)
        {
            return this.RQuery("select * from " + table + " where " + fieldTestCondition).Tables[0];
        }
        public DataRow SelectById(string table, int id)
        {
            return this.RQuery("select * from " + table + " where id='" + id + "'").Tables[0].Rows[0];
        }

        public DataRow SelectCount(string attribut, string table, string fieldTestCondition)
        {
            return this.RQuery("select count(" + attribut + ") as NbSalles from " + table + " where " + fieldTestCondition).Tables[0].Rows[0];
        }
    }
}