using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace School_Ms.Pages.teachers
{
    public class IndexModel : PageModel
    {
        string connectionstring = "Data Source=DESKTOP-C1H4MTN\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True;Encrypt=false;";
        public List<teacherinfo> teacherlist = new List<teacherinfo> ();

        public void OnGet()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                string sql = "SELECT * from teachers";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    teacherinfo teacherinfo = new teacherinfo();
                    teacherinfo.id = reader.GetInt32(0);
                    teacherinfo.name = reader.GetString(1);
                    teacherinfo.age = reader.GetString(2);
                    teacherinfo.gender = reader.GetString(3);
                    teacherinfo.email = reader.GetString(4);
                    teacherinfo.number = reader.GetString(5);
                    teacherinfo.subject = reader.GetString(6);
                    teacherinfo.address = reader.GetString(7);
                    teacherinfo.salary = reader.GetString(8);
                    teacherlist.Add(teacherinfo);

                }






            }
            catch(Exception ex)
            {
               Console.WriteLine (ex.ToString ());
            }
        }
        public class teacherinfo
        {
            public int id;
            public string age;
            public string name;
            public string gender;
            public string email;
            public string number;
            public string subject;
            public string address;
            public string salary;
        }
    }
}
