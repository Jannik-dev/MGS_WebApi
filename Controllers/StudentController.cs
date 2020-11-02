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
    public class StudentController : ApiController
    {
        static string table = "Students";

        // GET: api/Student
        public string Get()
        {
            List<int> ids = DB.AllIDs("Students");
            List<Student> students = new List<Student>();

            foreach (int id in ids)
            {
                students.Add(new Student(id));
            }

            return JsonConvert.SerializeObject(students);
        }

        //GET: api/Student/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new Student(id));
        }

        // POST: api/Student
        public void Post(TempStudent student) // Temp[Class], because [class] would update the corresponding Entry
        {
            object[] values = new object[] { student.Name, DB.GetProp($"SELECT ID FROM Teachers Where Name = '{student.Form}'") };
            DB.Insert("Students", values);
        }

        // PUT: api/Student
        public void Put(Student student)
        {

        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
            DB.Delete(table, id);
        }
    }

    public class TempStudent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Form { get; set; }
    }
}
