using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGS_Webservice.Models
{
    public class TeacherSubject
    {
        private static string table = "TeacherSubject";
        public TeacherSubject(int id)
        {
            this.ID = id;
        }

        public int ID { get; }

        /// <summary>
        /// The name of the teacher
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
        /// The subject the teacher is teaching
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
    }
}