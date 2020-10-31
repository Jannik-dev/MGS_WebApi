using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MGS_Webservice.Models
{
    class Config
    {
        public static SqlConnection Connection => new SqlConnection("Server=localhost;Database=school calendar;Integrated Security=SSPI");
    }
}
