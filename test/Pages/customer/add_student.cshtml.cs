using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace test.Pages.customer
{
    public class add_studentModel : PageModel
    {
        string connectionstring = "Data Source=DESKTOP-C1H4MTN\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True;Encrypt=false;";
        public string successmsg ="";
        public string errormsg = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            string Fullname = Request.Form["Fullname"];
            string Gender = Request.Form["Gender"];
            string phone = Request.Form["Phone"];
            string Address = Request.Form["Address"];
            string age = Request.Form["Age"];
            string subject = Request.Form["Subject"];
            string email = Request.Form["Email"];

            try
            {
                //save

                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                string sql = "insert into customers" +
                    "(full_name,gender,phone_number,address,email,age) values" +
                    " ( '" + Fullname + "' , '" + Gender + "', '" + phone + "' , '" + Address + "' , '" + email + "' , '" + age + "' )";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
               
               

            }
            catch (Exception ex)
            {
                errormsg = ex.Message;
            }
            //// Success 
            successmsg = " save success full";
            Response.Redirect("/customer/index");
        }
    }
}
