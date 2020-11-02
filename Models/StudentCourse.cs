using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGS_Webservice.Models
{
    public class StudentCourse
    {
        private static string table = "StudentCourse";
        public StudentCourse(int id)
        {
            this.ID = id;
        }

        public int ID { get; }

        /// <summary>
        /// The student attempting the course
        /// </summary>
        public string Student
        {
            get
            {
                return DB.GetProp($"SELECT Name FROM Students WHERE ID = (SELECT IDStudent FROM {table} WHERE ID = {this.ID});").ToString();
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET IDStudent = (SELECT ID FROM Students WHERE Name = '{value}') WHERE ID = {this.ID};");
            }
        }

        /// <summary>
        /// The coursename
        /// </summary>
        public string Course
        {
            get
            {
                return DB.GetProp($"SELECT Name FROM Courses WHERE ID = (SELECT IDCourse FROM {table} WHERE ID = {this.ID});").ToString();
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET IDCourse = (SELECT ID FROM Courses WHERE Name = '{value}') WHERE ID = {this.ID};");
            }
        }
    }
}