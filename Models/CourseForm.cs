using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGS_Webservice.Models
{
    public class CourseForm
    {
        private static string table = "CourseForm";
        public CourseForm(int id)
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
        /// The form that has the course
        /// </summary>
        public string Form
        {
            get
            {
                return DB.GetProp($"SELECT Name FROM Forms WHERE ID = (SELECT IDForm FROM {table} WHERE ID = {this.ID});").ToString();
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET IDForm = (SELECT ID FROM Forms WHERE Name = '{value}') WHERE ID = {this.ID};");
            }
        }

        /// <summary>
        /// The grade that has it course (it is for choosable courses)
        /// </summary>
        public int Grade
        {
            get
            {
                if (this.ID != 0)
                {
                    return (int)DB.GetProp($"SELECT Grade FROM {table} WHERE ID = {this.ID};");
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET Grade = '{value}' WHERE ID = {this.ID};");
            }
        }
    }
}