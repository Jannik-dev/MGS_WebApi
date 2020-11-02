using MGS_Webservice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MGS_Webservice.Controllers
{
    public class RoomController : ApiController
    {
        static string table = "Rooms";

        // GET: api/Room
        public string Get()
        {
            List<int> ids = DB.AllIDs(table);
            List<Room> rooms = new List<Room>();

            foreach (int id in ids)
            {
                rooms.Add(new Room(id));
            }

            return JsonConvert.SerializeObject(rooms);
        }

        //GET: api/Room/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new Room(id));
        }

        // POST: api/Room
        public void Post(TempRoom room) // Temp[Class], because [class] would update the corresponding Entry
        {
            object[] values = new object[] { room.Name };
            DB.Insert(table, values);
        }

        // PUT: api/Room
        public void Put(Room room)
        {

        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
            DB.Delete(table, id);
        }
    }

    public class TempRoom
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
