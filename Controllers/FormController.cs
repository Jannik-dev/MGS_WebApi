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
    public class FormController : ApiController
    {
        static string table = "Forms";

        // GET: api/Form
        public string Get()
        {
            List<int> ids = DB.AllIDs(table);
            List<Form> forms = new List<Form>();

            foreach (int id in ids)
            {
                forms.Add(new Form(id));
            }

            return JsonConvert.SerializeObject(forms);
        }

        //GET: api/Form/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new Form(id));
        }

        // POST: api/Form
        public void Post(TempForm form) // Temp[Class], because [class] would update the corresponding Entry
        {
            object[] values = new object[] { form.Name, DB.GetProp($"SELECT ID FROM Teachers Where Name = '{form.Classteacher}'") };
            DB.Insert(table, values);
        }

        // PUT: api/Form
        public void Put(Form form)
        {

        }

        // DELETE: api/Form/5
        public void Delete(int id)
        {
            DB.Delete(table, id);
        }
    }

    public class TempForm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Classteacher { get; set; }
    }
}
