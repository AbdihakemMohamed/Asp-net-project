using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Net;
using System.Numerics;
using System.Reflection;

namespace Bike_Ms.Pages.bikes
{
    public class add_bikesModel : PageModel
    {
        string connectionstring = "Data Source=DESKTOP-C1H4MTN\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True;Encrypt=false;";
        public string successmsg = "";
        public string errormsg = "";
        public void OnGet()
        {
           


        }


        public void OnPost()
        {
            string Modl = Request.Form["ah"];
            string type = Request.Form["type"];
            string status = Request.Form["status"];
            string location = Request.Form["location"];
            try
            {
                //save

                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                string sql = "insert into Bike" +
                "(Model,Type,Status,Location) values" +
                " ( '" + Modl + "' , '" + type + "', '" + status + "' , '" + location + "' )";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                errormsg = ex.Message;
            }
            //// Success 
            successmsg = " save success full";
            Response.Redirect("/bikes/index");



        }

    }
}
