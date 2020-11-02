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
    public class RoomResourceController : ApiController
    {
        static string table = "RoomResource";

        // GET: api/RoomResource
        public string Get()
        {
            List<int> ids = DB.AllIDs(table);
            List<RoomResource> roomResources = new List<RoomResource>();

            foreach (int id in ids)
            {
                roomResources.Add(new RoomResource(id));
            }

            return JsonConvert.SerializeObject(roomResources);
        }

        //GET: api/CourseTime/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new RoomResource(id));
        }

        // POST: api/CourseTime
        public void Post(TempRoomResource roomResource) // Temp[Class], because [class] would update the corresponding Entry
        {
            object[] values = new object[] { DB.GetProp($"SELECT ID FROM Rooms Where Name = '{roomResource.Room}'"), DB.GetProp($"SELECT ID FROM Resources Where Name = '{roomResource.Resource}'") };
            DB.Insert(table, values);
        }

        // PUT: api/CourseTime
        public void Put(CourseTime courseTime)
        {

        }

        // DELETE: api/CourseTime/5
        public void Delete(int id)
        {
            DB.Delete(table, id);
        }
    }

    public class TempRoomResource
    {
        public int ID { get; set; }
        public string Room { get; set; }
        public string Resource { get; set; }
    }
}
