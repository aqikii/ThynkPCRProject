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
       
        

      

        

        

    }


    public class availability
    {
        public String allocationid;
        public String venueid;
        public String allocationdate;

    }
}
