using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThynkPCRProject.Pages.PCR
{
    public class IndexModel : PageModel
    {
        public List<UserBooking> bookings = new List<UserBooking>();
        public List<UserBooking> bookingStatus = new List<UserBooking>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=DESKTOP-M8VG85I;Initial Catalog=ThynkTest_PCR;Integrated Security=True";
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM PcrTestBookings";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserBooking newbooking = new UserBooking();
                                newbooking.id = ""+reader.GetInt32(0);
                                newbooking.pcrtestvenueid = "" + reader.GetInt32(1);
                                newbooking.date = "" + reader.GetDateTime(2);
                                newbooking.idcard = reader.GetString(3);
                                newbooking.pcrbookingid = "" + reader.GetInt32(4);
                                newbooking.createddate = "" + reader.GetDateTime(5);
                                newbooking.modifieddate = "" + reader.GetDateTime(6);

                                bookings.Add(newbooking);
                            }
                        }
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception found;" + e);
            }
        }
    }

    public class UserBooking
    {
        public String id;
        public String pcrtestvenueid;
        public String date;
        public String idcard;
        public String pcrbookingid;
        public String createddate;
        public String modifieddate;

    }

    
}
