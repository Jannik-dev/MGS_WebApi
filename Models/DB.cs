using MGS_Webservice.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MGS_Webservice.Models
{
    class DB
    {
        public static void ExecuteQuery(string queryString)
        {
            using (SqlConnection connection = Config.Connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static object GetProp(string queryString)
        {
            using (SqlConnection connection = Config.Connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();

                object value = "";
                while (reader.Read())
                {
                    value = reader[0];
                }

                reader.Close();
                connection.Close();

                return value;
            }
        }
        public static List<int> AllIDs(string table)
        {
            string queryString = $"SELECT * FROM {table} AS t WHERE 0 = 0;";
            List<int> items = new List<int>();

            using (SqlConnection connection = Config.Connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    items.Add((int)reader[0]);
                }

                reader.Close();
                connection.Close();
            }
            return items;
        }
        public static void Insert(string table, object[] values)
        {
            DB.ExecuteQuery($"INSERT INTO {table} VALUES ({String.Join(", ", values)};");
        }
    }
}
 