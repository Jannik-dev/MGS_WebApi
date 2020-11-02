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
        static string table = "Teachers";

        // GET: api/Teacher
        public string Get()
        {
            List<int> ids = DB.AllIDs(table);
            List<Teacher> teachers = new List<Teacher>();

            foreach (int id in ids){
                teachers.Add(new Teacher(id));
            }

            return JsonConvert.SerializeObject(teachers);
        }

        //GET: api/Teacher/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new Teacher(id));
        }

        // POST: api/Teacher
        public void Post(TempTeacher teacher) // Temp[Class], because [class] would update the corresponding Entry
        {
            object[] values = new object[] { teacher.Name, teacher.Short, teacher.Hours };
            DB.Insert(table, values); 
        }

        // PUT: api/Teacher
        public void Put(Teacher teacher) 
        {
            
        }

        // DELETE: api/Teacher/5
        public void Delete(int id)
        {
            DB.Delete(table, id);
        }
    }

    public class TempTeacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Short { get; set; }
        public int Hours { get; set; }
    }
}
