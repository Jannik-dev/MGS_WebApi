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
    public class SubjectController : ApiController
    {
        static string table = "Subjects";

        // GET: api/Subject
        public string Get()
        {
            List<int> ids = DB.AllIDs(table);
            List<Subject> subjects = new List<Subject>();

            foreach (int id in ids)
            {
                subjects.Add(new Subject(id));
            }

            return JsonConvert.SerializeObject(subjects);
        }

        //GET: api/Subject/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new Subject(id));
        }

        // POST: api/Subject
        public void Post(TempSubject subject) // Temp[Class], because [class] would update the corresponding Entry
        {
            object[] values = new object[] { subject.Name, subject.Short };
            DB.Insert(table, values);
        }

        // PUT: api/Subject
        public void Put(Subject subject)
        {

        }

        // DELETE: api/Subject/5
        public void Delete(int id)
        {
            DB.Delete(table, id);
        }
    }

    public class TempSubject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Short { get; set; }
    }
}
