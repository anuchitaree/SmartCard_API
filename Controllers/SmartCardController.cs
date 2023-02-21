using Microsoft.AspNetCore.Mvc;
using SmartCart_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartCartTool_API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SmartCardController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SmartCardController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // POST api/<SmartCardController>
        //https://localhost:7135/api/v1/SmartCard/partnumber
        [HttpPost("partnumber")]
        public ActionResult PostPartNumber([FromBody] PartNumber partnumber)
        {

            if (partnumber == null) return BadRequest();


            var path = _configuration["ConnectionFolder"];

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            path += "\\partnumber.txt";

            using (StreamWriter writetext = new StreamWriter(path))
            {
                writetext.Write($"{partnumber.PartNoSubAssy},{partnumber.LotId},{partnumber.TimeStamp}");
            }

            return Ok(partnumber);

        }













    }
}
