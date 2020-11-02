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
    public class CourseTimeController : ApiController
    {
        static string table = "CourseTime";

        // GET: api/CourseTime
        public string Get()
        {
            List<int> ids = DB.AllIDs(table);
            List<CourseTime> courseTimes = new List<CourseTime>();

            foreach (int id in ids)
            {
                courseTimes.Add(new CourseTime(id));
            }

            return JsonConvert.SerializeObject(courseTimes);
        }

        //GET: api/CourseTime/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new CourseTime(id));
        }

        // POST: api/CourseTime
        public void Post(TempCourseTime courseTime) // Temp[Class], because [class] would update the corresponding Entry
        {
            object[] values = new object[] { DB.GetProp($"SELECT ID FROM Courses Where Name = '{courseTime.Course}'"), DB.GetProp($"SELECT ID FROM Forms Where Name = '{courseTime.Day}'"), courseTime.LessonNumber };
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

    public class TempCourseTime
    {
        public int ID { get; set; }
        public string Course { get; set; }
        public string Day { get; set; }
        public int LessonNumber { get; set; }
    }
}
