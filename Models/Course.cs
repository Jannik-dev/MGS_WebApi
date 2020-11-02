using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGS_Webservice.Models
{
    public class Course
    {
        private static string table = "Courses";
        public Course(int id)
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
        /// The subject of the course
        /// </summary>
        public string Subject
        {
            get
            {
                return DB.GetProp($"SELECT Name FROM Subjects WHERE ID = (SELECT IDSubject FROM {table} WHERE ID = {this.ID});").ToString();
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET IDSubject = (SELECT ID FROM Subjects WHERE Name = '{value}') WHERE ID = {this.ID};");
            }
        }

        /// <summary>
        /// The classteacher of the course
        /// </summary>
        public string Teacher
        {
            get
            {
                return DB.GetProp($"SELECT Name FROM Teachers WHERE ID = (SELECT IDTeacher FROM {table} WHERE ID = {this.ID});").ToString();
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET IDTeacher = (SELECT ID FROM Teachers WHERE Name = '{value}') WHERE ID = {this.ID};");
            }
        }

        /// <summary>
        /// The room the course is in
        /// </summary>
        public string Room
        {
            get
            {
                return DB.GetProp($"SELECT Name FROM Rooms WHERE ID = (SELECT IDRoom FROM {table} WHERE ID = {this.ID});").ToString();
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET IDRoom = (SELECT ID FROM Rooms WHERE Name = '{value}') WHERE ID = {this.ID};");
            }
        }

        /// <summary>
        /// The other course that replaces it in the enxt week
        /// </summary>
        public string AlternatingCourse
        {
            get
            {
                return DB.GetProp($"SELECT Name FROM {table} WHERE ID = IDAlternatingCourse;").ToString();
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET IDAlternatingCourse = '{value}' WHERE ID = {this.ID};");
            }
        }
    }
}