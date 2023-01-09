using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WE_55_API.Models;

namespace WE_55_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {

            SqlCommand sc = new SqlCommand("SELECT * FROM tbl_TimeSlot WHERE Status='1'", Connection.GetSqlConnection());
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            sda.Fill(dt);
            return new JsonResult(dt);
        }
        [HttpPost]

        public JsonResult Post(TimeSlot timeslot)
        {
            string query = @"INSERT INTO tbl_TimeSlot VALUES(@TSCode, @StartTime, @EndTime, '1')";
            SqlCommand sc = new SqlCommand(query, Connection.GetSqlConnection());
            sc.Parameters.AddWithValue("@TSId", timeslot.TSId);
            sc.Parameters.AddWithValue("@TSCode", timeslot.TSCode);
            sc.Parameters.AddWithValue("@StartTime", timeslot.StartTime);
            sc.Parameters.AddWithValue("@EndTime", timeslot.EndTime);
            sc.ExecuteNonQuery();
            return new JsonResult("TimeSlot Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(TimeSlot timeslot)
        {
            string query = @"UPDATE tbl_TimeSlot SET TSCode =@TSCode, StartTime= @StartTime,EndTime= @EndTime WHERE TSId=@TSId";
            SqlCommand sc = new SqlCommand(query, Connection.GetSqlConnection());

            sc.Parameters.AddWithValue("@TSCode", timeslot.TSCode);
            sc.Parameters.AddWithValue("@StartTime", timeslot.StartTime);
            sc.Parameters.AddWithValue("@EndTime", timeslot.EndTime);
            sc.Parameters.AddWithValue("@TSId", timeslot.TSId);
            sc.ExecuteNonQuery();
            return new JsonResult("TimeSlot Updated Successfully");
        }
        [HttpDelete]
        public JsonResult Delete(TimeSlot timeslot)
        {
            string query = @"UPDATE tbl_TimeSlot SET Status ='0' WHERE TSId=@TSId";
            SqlCommand sc = new SqlCommand(query, Connection.GetSqlConnection());
            sc.Parameters.AddWithValue("@TSId", timeslot.TSId);

            sc.ExecuteNonQuery();
            return new JsonResult("TimeSlot Deleted Successfully");
        }
    }
}