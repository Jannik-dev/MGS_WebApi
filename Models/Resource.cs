using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGS_Webservice.Models
{
    public class Resource
    {
        private static string table = "Resources";
        public Resource(int id)
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
    }
}