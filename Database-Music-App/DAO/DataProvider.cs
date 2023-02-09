using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Music_App.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
            private set { instance = value; }
        }

        private DataProvider() { }

        private string connectionSTR = "Server = AMOSIVOR1710\\SQLEXPRESS ; Database = MUSIC_PLAYER; Integrated Security = True";
        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    foreach (string item in listPara)
                    {
                        Console.WriteLine(item);
                    }
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.Add(item, parameters[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }
            return data;

        }


        // insert, update: check success or not ? - return number or row success when
        // insert, update
        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    foreach (string item in listPara)
                    {
                        Console.WriteLine(item);
                    }
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.Add(item, parameters[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    foreach (string item in listPara)
                    {
                        Console.WriteLine(item);
                    }
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.Add(item, parameters[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar(); // return the first cell implement success

                connection.Close();
            }

            return data;
        }
    }
}
