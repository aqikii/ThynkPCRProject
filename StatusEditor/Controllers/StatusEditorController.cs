using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
  
namespace StatusEditor.Controllers
{
    [ApiController]
    public class StatusEditorController : ControllerBase
    {
        String connectionString = "Data Source=DESKTOP-M8VG85I;Initial Catalog=ThynkTest_PCR;Integrated Security=True";
        
        [HttpGet("editstatus/{id}/{status}")]
        public void editstatus(int id, int status)
        {
            int _id = id;
            int _status = status;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "UPDATE [ThynkTest_PCR].[dbo].[PcrTestBookings] " +
                    "SET PcrTestBookingStatusId=@status WHERE id=@id";
                using(SqlCommand command = new SqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@id", _id);
                    command.Parameters.AddWithValue("@status", _status);
                    command.ExecuteNonQuery();
                }
            }
        }

        [HttpGet("editoutcome/{id}/{outcome}")]
        public void editoutcome(int id, int outcome)
        {
            int _id = id;
            int _outcome = outcome;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "UPDATE [ThynkTest_PCR].[dbo].[PcrTestBookings] " +
                    "SET PcrTestResultTypeId=@outcome WHERE id=@id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", _id);
                    command.Parameters.AddWithValue("@outcome", _outcome);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
