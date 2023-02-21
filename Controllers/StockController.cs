using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCart_API.Models;

namespace SmartCart_API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpPost("receive")]
        public ActionResult ReceiveFromSmartCard([FromBody] PartNumber partNumber)
        {

            return Ok(partNumber);
        }
    }
}
