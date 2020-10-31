using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MGS_Webservice.Models
{
    public class Teacher
    {
        private static string table = "Teachers";
        public Teacher(int id)
        {
            this.ID = id;
        }

        public int ID { get; }

        public string Name
        {
            get
            {
                return DB.GetProp($"SELECT Name FROM {table} WHERE ID = {this.ID};").ToString();
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET Name = '{value}' WHERE ID = {this.ID};");
            }
        }

        /// <summary>
        /// Abbreviation of the teacher (2 Letters)
        /// </summary>
        public string Short
        {
            get
            {
                return DB.GetProp($"SELECT Short FROM {table} WHERE ID = {this.ID};").ToString();
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET Short = '{value}' WHERE ID = {this.ID};");
            }
        }

        /// <summary>
        /// Represents the worked hours per week
        /// </summary>
        public int Hours
        {
            get
            {
                if (this.ID != 0)
                {
                    return (int)DB.GetProp($"SELECT Hours FROM {table} WHERE ID = {this.ID};");
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET Hours = '{value}' WHERE ID = {this.ID};");
            }
        }
    }
}