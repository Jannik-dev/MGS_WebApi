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
    public class CourseFormController : ApiController
    {
        static string table = "CourseForm";

        // GET: api/CourseForm
        public string Get()
        {
            List<int> ids = DB.AllIDs(table);
            List<CourseForm> courseForms = new List<CourseForm>();

            foreach (int id in ids)
            {
                courseForms.Add(new CourseForm(id));
            }

            return JsonConvert.SerializeObject(courseForms);
        }

        //GET: api/CourseForm/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new CourseForm(id));
        }

        // POST: api/CourseForm
        public void Post(TempCourseForm courseForm) // Temp[Class], because [class] would update the corresponding Entry
        {
            object[] values = new object[] { DB.GetProp($"SELECT ID FROM Courses Where Name = '{courseForm.Course}'"), DB.GetProp($"SELECT ID FROM Forms Where Name = '{courseForm.Form}'"), courseForm.Grade};
            DB.Insert(table, values);
        }

        // PUT: api/CourseForm
        public void Put(Form form)
        {

        }

        // DELETE: api/CourseForm/5
        public void Delete(int id)
        {
            DB.Delete(table, id);
        }
    }

    public class TempCourseForm
    {
        public int ID { get; set; }
        public string Course { get; set; }
        public string Form { get; set; }
        public int Grade { get; set; }
    }
}
