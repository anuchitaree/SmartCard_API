using Microsoft.AspNetCore.Mvc;
using SmartCard_API.Interfaces;
using SmartCard_API.Models;
using SmartCart_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartCartTool_API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SmartCardController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISystemIO _systemIO;
        public SmartCardController(IConfiguration configuration,ISystemIO systemIO)
        {
            _configuration = configuration;
            _systemIO = systemIO;
        }

        // POST api/<SmartCardController>
        //https://localhost:7135/api/v1/SmartCard/partnumber
        [HttpPost("partnumber")]
        public ActionResult PostPartNumber([FromBody] PartNumber partnumber)
        {

            if (partnumber == null) return BadRequest();


            var path = _configuration["ConnectionFolder"];

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path!);

            path += "\\partnumber.txt";

            if (_systemIO.IsFileExist(path))
            {
                var ngresult = new StatusModel()
                {
                    Status="ng",
                    Detail="busy",
                };
                return Ok(ngresult);
            }

            if (partnumber.PartNoSubAssy.Length != 12 && partnumber.TimeStamp.Length != 19)
            {
                var ng1 = new StatusModel()
                {
                    Status = "ng",
                    Detail = "PartNoSubAssy is not equal 12 characters or TimeStamp is not equal 19 charactors",
                };
                return Ok(ng1);
            }


            using (StreamWriter writetext = new StreamWriter(path))
            {
                writetext.Write($"{partnumber.PartNoSubAssy},{partnumber.LotId},{partnumber.TimeStamp}");
            }

            var okresult = new StatusModel()
            {
                Status = "ok",
                Detail = "",
            };
            return Ok(okresult);

        }













    }
}
