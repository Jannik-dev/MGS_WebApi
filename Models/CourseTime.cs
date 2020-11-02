using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGS_Webservice.Models
{
    public class CourseTime
    {
        private static string table = "CourseForm";
        public CourseTime(int id)
        {
            this.ID = id;
        }

        public int ID { get; }

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

        /// <summary>
        /// The day the course occurs
        /// </summary>
        public string Day
        {
            get
            {
                return DB.GetProp($"SELECT Name FROM Days WHERE ID = (SELECT IDDay FROM {table} WHERE ID = {this.ID});").ToString();
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET IDDay = (SELECT ID FROM Days WHERE Name = '{value}') WHERE ID = {this.ID};");
            }
        }

        /// <summary>
        /// The lesson number of the course at the day
        /// </summary>
        public int LessonNumber
        {
            get
            {
                if (this.ID != 0)
                {
                    return (int)DB.GetProp($"SELECT LessonNumber FROM {table} WHERE ID = {this.ID};");
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET LessonNumber = '{value}' WHERE ID = {this.ID};");
            }
        }
    }
}