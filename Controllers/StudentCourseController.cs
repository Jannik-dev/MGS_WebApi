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
    public class StudentCourseController : ApiController
    {
        static string table = "StudentCourse";

        // GET: api/RoomResource
        public string Get()
        {
            List<int> ids = DB.AllIDs(table);
            List<StudentCourse> studentCourses = new List<StudentCourse>();

            foreach (int id in ids)
            {
                studentCourses.Add(new StudentCourse(id));
            }

            return JsonConvert.SerializeObject(studentCourses);
        }

        //GET: api/CourseTime/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new StudentCourse(id));
        }

        // POST: api/CourseTime
        public void Post(TempStudentCourse studentCourse) // Temp[Class], because [class] would update the corresponding Entry
        {
            object[] values = new object[] { DB.GetProp($"SELECT ID FROM Students Where Name = '{studentCourse.Student}'"), DB.GetProp($"SELECT ID FROM Courses Where Name = '{studentCourse.Course}'") };
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

    public class TempStudentCourse
    {
        public int ID { get; set; }
        public string Student { get; set; }
        public string Course { get; set; }
    }
}
