using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGS_Webservice.Models
{
    public class Student
    {
        private static string table = "Students";
        public Student(int id)
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
        /// The form the student is in
        /// </summary>
        public string Form
        {
            get
            {
                return DB.GetProp($"SELECT Name FROM Forms WHERE ID = (SELECT IDForm FROM {table} WHERE ID = {this.ID});").ToString();
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET IDForm = '(SELECT ID FROM Forms Where Name = '{value}')' WHERE ID = {this.ID};");
            }
        }
    }
}