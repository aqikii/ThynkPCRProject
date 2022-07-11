using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThynkPCRProject.Pages.PCR
{
    public class CreateModel : PageModel
    {
       
        public List<availability> availabilitieslist = new List<availability>();
        public UserBooking booking = new UserBooking();
        String connectionString = "Data Source=DESKTOP-M8VG85I;Initial Catalog=ThynkTest_PCR;Integrated Security=True";
        public String errorMessage = "";
        public String successmessage = "";
        public void OnGet()
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT PcrTestVenueAllocationId, PcrTestVenueId,AllocationDate FROM PcrTestVenueAllocations WHERE NumberOfSpaces>0 ORDER BY AllocationDate,pcrtestvenueallocationid";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                availability availabilities = new availability();
                                availabilities.allocationid = "" + reader.GetInt32(0);
                                availabilities.venueid = "" + reader.GetInt32(1);
                                availabilities.allocationdate = "" + reader.GetDateTime(2);
                                availabilitieslist.Add(availabilities);
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception found;" + e);
            }
        }
       
        

        public void OnPost(String date, String allocation)
        {
            booking.idcard = Request.Form["idcard"];
            booking.pcrtestvenueid = Request.Form["comboA"];
            booking.date = ViewData["Date"].ToString();
            if(booking.idcard ==null || booking.pcrtestvenueid == null || booking.date == null)
            {
                errorMessage = "All Fields are required";
                return;
            }

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO PcrTestBookings " +
                        "PcrTestVenueId,BookingDate,IdentityCardNumber,PcrTestBookingStatusId VALUES " +
                        "@venueid, @date, @idcardnumber, @statusid";

                    using(SqlCommand command = new SqlCommand(sql,connection))
                    {
                        command.Parameters.AddWithValue("@venueid", booking.pcrtestvenueid);
                        command.Parameters.AddWithValue("@date", booking.date);
                        command.Parameters.AddWithValue("@idcardnumber", booking.idcard);
                        command.Parameters.AddWithValue("@statusid", 1);
                    }
                }
            }catch(Exception ex)
            {
                errorMessage = ex.Message;
                return; 
            }
            Response.Redirect("/PCR/Index");
        }

        

        

    }


    public class availability
    {
        public String allocationid;
        public String venueid;
        public String allocationdate;

    }
}
