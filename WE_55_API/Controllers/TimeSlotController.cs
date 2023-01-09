using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace WE_55_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            string query = "SELECT * FROM tbl_TimeSlot";
            SqlCommand sc = new SqlCommand(query,Connection.GetSqlConnection());
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            sda.Fill(dt);
            return new JsonResult("");
        }
    }
}
