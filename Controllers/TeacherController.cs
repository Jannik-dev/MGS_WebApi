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
    public class TeacherController : ApiController
    {
        List<Teacher> teachers = new List<Teacher>();

        // GET: api/Teacher
        public string Get()
        {
            List<int> ids = DB.AllIDs("Teachers");
            List<Teacher> teachers = new List<Teacher>();

            foreach (int id in ids){
                teachers.Add(new Teacher(id));
            }

            return JsonConvert.SerializeObject(teachers);
        }

        // GET: api/Teacher/5
        public Teacher Get(int id)
        {
            return new Teacher(id);
        }

        // POST: api/Teacher
        public void Post([FromBody] Teacher teacher)
        {
            object[] values = new object[] { teacher.Name, teacher.Short, teacher.Hours };
            DB.Insert("Teachers", values);
        }

        // PUT: api/Teacher/5
        public void Put(int id, [FromBody]string value)
        {
            object[] values = new object[] { value.Split(',') };
            DB.Insert("Teachers", values);
        }

        // DELETE: api/Teacher/5
        public void Delete(int id)
        {
            DB.ExecuteQuery($"DELETE FROM Teachers WHERE ID = id;");
        }
    }
}
