﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCard_API.Models;
using SmartCart_API.Models;

namespace SmartCart_API.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpPost("end_write_sub_assy")]
        public ActionResult ReceiveFromSmartCard([FromBody] PartNumber partNumber)
        {
            var okresult = new StatusModel()
            {
                Status = "ok",
                Detail = "",
            };
            return Ok(okresult); 
        }
    }
}
