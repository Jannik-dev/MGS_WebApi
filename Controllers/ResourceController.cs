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
    public class ResourceController : ApiController
    {
        static string table = "Resources";

        // GET: api/Resource
        public string Get()
        {
            List<int> ids = DB.AllIDs(table);
            List<Resource> resources = new List<Resource>();

            foreach (int id in ids)
            {
                resources.Add(new Resource(id));
            }

            return JsonConvert.SerializeObject(resources);
        }

        //GET: api/Resource/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new Resource(id));
        }

        // POST: api/Resource
        public void Post(TempResource resource) // Temp[Class], because [class] would update the corresponding Entry
        {
            object[] values = new object[] { resource.Name };
            DB.Insert(table, values);
        }

        // PUT: api/Resource
        public void Put(Resource resource)
        {

        }

        // DELETE: api/Resource/5
        public void Delete(int id)
        {
            DB.Delete(table, id);
        }
    }

    public class TempResource
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
