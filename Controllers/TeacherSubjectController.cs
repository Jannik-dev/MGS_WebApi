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
    public class TeacherSubjectController : ApiController
    {
        static string table = "TeacherSubject";

        // GET: api/RoomResource
        public string Get()
        {
            List<int> ids = DB.AllIDs(table);
            List<TeacherSubject> teacherSubjects = new List<TeacherSubject>();

            foreach (int id in ids)
            {
                teacherSubjects.Add(new TeacherSubject(id));
            }

            return JsonConvert.SerializeObject(teacherSubjects);
        }

        //GET: api/CourseTime/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new TeacherSubject(id));
        }

        // POST: api/CourseTime
        public void Post(TempTeacherSubject teacherSubject) // Temp[Class], because [class] would update the corresponding Entry
        {
            object[] values = new object[] { DB.GetProp($"SELECT ID FROM Teachers Where Name = '{teacherSubject.Teacher}'"), DB.GetProp($"SELECT ID FROM Subjects Where Name = '{teacherSubject.Subject}'") };
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

    public class TempTeacherSubject
    {
        public int ID { get; set; }
        public string Teacher { get; set; }
        public string Subject { get; set; }
    }
}
