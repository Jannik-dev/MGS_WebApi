using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGS_Webservice.Models
{
    public class Form
    {
        private static string table = "Forms";
        public Form(int id)
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
        /// The classteacher of the form
        /// </summary>
        public string Classteacher
        {
            get
            {
                return DB.GetProp($"SELECT Name FROM Teachers WHERE ID = (SELECT IDClassteacher FROM {table} WHERE ID = {this.ID});").ToString();              
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET IDClassteacher = (SELECT ID FROM Teachers WHERE Name = '{value}') WHERE ID = {this.ID};");
            }
        }
    }
}