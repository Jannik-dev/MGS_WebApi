using MGS_Webservice.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MGS_Webservice.Models
{
    class DB
    {
        /// <summary>
        /// Executes an sql-query
        /// </summary>
        /// <param name="queryString">Sql-Query</param>
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

        /// <summary>
        /// Gets the value of a certain property based on an sql-query
        /// </summary>
        /// <param name="queryString">Sql-Query</param>
        /// <returns>Value of the property</returns>
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

        /// <summary>
        /// Provides a list with all ids
        /// </summary>
        /// <param name="table">The selected table</param>
        /// <returns>A list with ids</returns>
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

        /// <summary>
        /// Creates a new entry in the database 
        /// </summary>
        /// <param name="table">In which table it should be inserted</param>
        /// <param name="values">The values it should insert</param>
        public static void Insert(string table, object[] values)
        {
            string s = String.Join("', '", values);
            DB.ExecuteQuery($"INSERT INTO {table} VALUES ('{s}');");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(string table, int id)
        {
            DB.ExecuteQuery($"DELETE FROM {table} WHERE ID = {id};");
        }
    }
}
 