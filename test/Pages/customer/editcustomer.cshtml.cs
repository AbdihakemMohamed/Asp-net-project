using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using test.Pages.customer;

namespace School_Ms.Pages.customer
{
    public class editcustomerModel : PageModel
    {


        public string con = "Data Source=DESKTOP-C1H4MTN\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True;Encrypt=false;";
        public string errormsg = "";
        public string successmsg = "";
        public customerinfo customerinfo = new customerinfo();
        public void OnGet()
        {
            String id = Request.Query["id"];
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string sql = "SELECT * from customers where customer_id = '" + id + "' ";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                
                customerinfo.customer_id = reader.GetInt32(0);
                customerinfo.full_name = reader.GetString(1);
                customerinfo.gender = reader.GetString(2);
                customerinfo.phone_number = reader.GetString(3);
                customerinfo.address = reader.GetString(4);
                customerinfo.email = reader.GetString(5);
                customerinfo.age = reader.GetString(6);
              

            }
            connection.Close();
        }


        public void OnPost()
        {
            string Fullname = Request.Form["Fullname"];
            string Gender = Request.Form["Gender"];
            string phone = Request.Form["Phone"];
            string Address = Request.Form["Address"];
            string age = Request.Form["Age"];
            string email = Request.Form["Email"];
            string id = Request.Form["id"];

            try
            {

                SqlConnection connection = new SqlConnection(con);
                connection.Open();
                string sql = " UPDATE customers set " +
                    "full_name = '" + Fullname + "'," +
                    "gender = '" + Gender + "' ," +
                    "phone_number = '" + phone + "' , " +
                    "address = '" + Address + "', " +
                    "email = '" + email + "', " +
                    "age = '" + age + "' " +
                    "where customers = '" + id + "' ";

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();


            }
            catch (Exception ex)
            {
                errormsg = ex.Message;
                return;
            }

            Response.Redirect("/customer/Index");


        }
    }


}
