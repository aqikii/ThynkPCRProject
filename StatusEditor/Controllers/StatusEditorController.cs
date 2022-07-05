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
        public void editstatus(string id, string status)
        {
            String _id = id;
            String _status = status;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "UPDATE users "+
                    "SET status=@status WHERE id=@id";
                using(SqlCommand command = new SqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@id", _id);
                    command.Parameters.AddWithValue("@status", _status);
                    command.ExecuteNonQuery();
                }
            }
        }

        [HttpGet("editoutcome/{id}/{outcome}")]
        public void editoutcome(string id, string outcome)
        {
            String _id = id;
            String _outcome = outcome;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "UPDATE users " +
                    "SET status=@status WHERE id=@id";
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
}
