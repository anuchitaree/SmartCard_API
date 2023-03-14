using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCard_API.Data;
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
        private readonly NpgContext db;
        public SmartCardController(IConfiguration configuration, ISystemIO systemIO, NpgContext npgContext)
        {
            _configuration = configuration;
            _systemIO = systemIO;
            db = npgContext;
        }

        // POST api/<SmartCardController>
        //https://localhost:7135/api/v1/SmartCard/partnumber
        [HttpPost("partnumber")]
        public async Task<ActionResult> PostPartNumber([FromBody] PartNumber partnumber)
        {

            try
            {

                var aaa = db.Database.CanConnect();

                if (partnumber == null) return BadRequest();


                //=== no master part ==//
                var exitsmaster = await db.Smartcards.Where(x => x.Partnumber == partnumber.PartNoSubAssy).ToListAsync();
                if (exitsmaster.Count == 0)
                {
                    var notfound = new StatusModel()
                    {
                        Status = "ng",
                        Detail = "not_found_master_part",
                    };
                    return Ok(notfound);
                }



                //== busy ==//
                var path = _configuration["ConnectionFolder"];

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path!);

                path += "\\partnumber.txt";

                if (_systemIO.IsFileExist(path))
                {
                    var ngresult = new StatusModel()
                    {
                        Status = "ng",
                        Detail = "busy",
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

                //===  OK ==//
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
            catch (Exception ex)
            {
                return Ok(new { Status="ng", Detail = ex.Message });
            }
        }













    }
}
