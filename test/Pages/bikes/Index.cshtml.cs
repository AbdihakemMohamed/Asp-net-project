using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using test.Pages.customer;

namespace School_Ms.Pages.bikes
{
    public class IndexModel : PageModel
    {

        string connectionstring = "Data Source=DESKTOP-C1H4MTN\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True;Encrypt=false;";
        public List<bikesinfo> bikeslist = new List<bikesinfo>();
        public string errormsg = "";
        public string successmsg = "";
        public void OnGet()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                string sql = "SELECT *  from Bike";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    bikesinfo bikesinfo = new bikesinfo();
                    bikesinfo.BikeID = reader.GetInt32(0);
                    bikesinfo.Model = reader.GetString(1);
                    bikesinfo.Type = reader.GetString(2);
                    bikesinfo.Status = reader.GetString(3);
                    bikesinfo.Location = reader.GetString(4);
                    bikeslist.Add(bikesinfo);

                }



            }
            catch (Exception ex)
            {
                errormsg = ex.Message;
                return;

            }



        }


        public class bikesinfo
        {
            public int BikeID;
            public string Model;
            public string Type;
            public string Status;
            public string Location;

        }







    }
}
