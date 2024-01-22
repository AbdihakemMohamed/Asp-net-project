using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace test.Pages.customer
{
    public class IndexModel : PageModel
    {
        string connectionstring = "Data Source=DESKTOP-C1H4MTN\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True;Encrypt=false;";
        public List<customerinfo> customerlist = new List<customerinfo> ();
        public string errormsg ="";
        public string successmsg = "";


        public void OnGet()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                string sql = "SELECT *  from customers";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    customerinfo customerinfo = new customerinfo();
                    customerinfo.customer_id = reader.GetInt32(0);
                    customerinfo.full_name = reader.GetString(1);
                    customerinfo.gender = reader.GetString(2); 
                    customerinfo.phone_number = reader.GetString(3);
                    customerinfo.address = reader.GetString(4);
                    customerinfo.email = reader.GetString(5);
                    customerinfo.age = reader.GetString(6);
                    customerlist.Add(customerinfo);

                }



            }
            catch (Exception ex)
            {
                errormsg = ex.Message;
                return;
            
            }




        }
    }
    public class customerinfo
    {
        public int customer_id;
        public string full_name;
        public string gender;
        public string phone_number;
        public string address;
        public string email;
        public string age;

    }


}
