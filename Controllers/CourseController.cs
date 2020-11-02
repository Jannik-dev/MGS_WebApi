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
    public class CourseController : ApiController
    {
        static string table = "Courses";

        // GET: api/Course
        public string Get()
        {
            List<int> ids = DB.AllIDs(table);
            List<Course> courses = new List<Course>();

            foreach (int id in ids)
            {
                courses.Add(new Course(id));
            }

            return JsonConvert.SerializeObject(courses);
        }

        //GET: api/Course/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new Course(id));
        }

        // POST: api/Course
        public void Post(TempCourse course) // Temp[Class], because [class] would update the corresponding Entry
        {
            object[] values = new object[] { course.Name, DB.GetProp($"SELECT ID FROM Subjects Where Name = '{course.Subject}'"), DB.GetProp($"SELECT ID FROM Rooms Where Name = '{course.Room}'"), DB.GetProp($"SELECT ID FROM Teachers Where Name = '{course.Teacher}'"), DB.GetProp($"SELECT ID FROM {table} WHERE ID = IDAlternatingCourse") };
            DB.Insert(table, values);
        }

        // PUT: api/Course
        public void Put(Course course)
        {

        }

        // DELETE: api/Course/5
        public void Delete(int id)
        {
            DB.Delete(table, id);
        }
    }

    public class TempCourse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public string Room { get; set; }
        public string AlternatingCourse { get; set; }
    }
}
