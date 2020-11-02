using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGS_Webservice.Models
{
    public class RoomResource
    {
        private static string table = "RoomResource";
        public RoomResource(int id)
        {
            this.ID = id;
        }

        public int ID { get; }

        /// <summary>
        /// The room number represented by 3 numbers
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
        /// The resource that is avaiable in the room
        /// </summary>
        public string Resource
        {
            get
            {
                return DB.GetProp($"SELECT Name FROM Resources WHERE ID = (SELECT IDResource FROM {table} WHERE ID = {this.ID});").ToString();
            }
            set
            {
                DB.ExecuteQuery($"UPDATE {table} SET IDResource = (SELECT ID FROM Resources WHERE Name = '{value}') WHERE ID = {this.ID};");
            }
        }
    }
}