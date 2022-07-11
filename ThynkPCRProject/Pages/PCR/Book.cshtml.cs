using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThynkPCRProject.Pages.PCR
{
    public class BookModel : PageModel
    {
        public void OnPost(string allocationid, string VenueID, string date)
        {
            /*_allocationid = allocationid;
            _venueid = VenueID;
            _date = date;
            idcard = Request.Form["idnumber"];*/
            string connectionString = "Data Source=DESKTOP-M8VG85I;Initial Catalog=ThynkTest_PCR;Integrated Security=True";
            string errorMessage = "";
            

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO PcrTestBookings (PcrTestVenueId,BookingDate,IdentityCardNumber,PcrTestBookingStatusId) VALUES (@venueid, @date, @idcardnumber, @statusid)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@venueid", VenueID.ToString());
                        command.Parameters.AddWithValue("@date", date.ToString());
                        command.Parameters.AddWithValue("@idcardnumber", Request.Form["idnumber"].ToString());
                        command.Parameters.AddWithValue("@statusid", 1.ToString());

                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/PCR/Index");


        }
    }
}
