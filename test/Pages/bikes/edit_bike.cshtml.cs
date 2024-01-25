using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Net;
using System.Numerics;
using System.Reflection;
using test.Pages.customer;
using static School_Ms.Pages.bikes.IndexModel;

namespace Bike_Ms.Pages.bikes
{
    public class edit_bikeModel : PageModel
    {
        public string con = "Data Source=DESKTOP-C1H4MTN\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True;Encrypt=false;";
        public string errormsg = "";
        public string successmsg = "";
        public bikesinfo bikesinfo = new bikesinfo();
        public void OnGet()
        {
            String id = Request.Query["id"];
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string sql = "SELECT * from Bike where BikeID = '" + id + "' ";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                bikesinfo.BikeID = reader.GetInt32(0);
                bikesinfo.Model = reader.GetString(1);
                bikesinfo.Type = reader.GetString(2);
                bikesinfo.Status = reader.GetString(3);
                bikesinfo.Location = reader.GetString(4);



            }
            connection.Close();



        }

        public void Onpost()
        {
            String id = Request.Form["id"];
            string Modl = Request.Form["ah"];
            string type = Request.Form["type"];
            string status = Request.Form["status"];
            string location = Request.Form["location"];
            try
            {

                SqlConnection connection = new SqlConnection(con);
                connection.Open();
                string sql = "UPDATE Bike SET Model = '" + Modl + "', Type = '" + type + "', Status = '" + status + "', Location = '" + location + "' where BikeID='"+ id +"'     ";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                errormsg = ex.Message;
                return;
            }
            successmsg = "Updated Successfully";
            Response.Redirect("/bikes/Index");
        }
    }
}
