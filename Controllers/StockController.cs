using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCard_API.Data;
using SmartCard_API.Models;

namespace SmartCart_API.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly NpgContext db;

        public StockController(NpgContext npgContext)
        {
            db = npgContext;

        }

        [HttpPost("end_write_sub_assy")]
        public async Task<ActionResult> End_write_sub_assy([FromBody] NormalReturn partNumber)
        {

            var existing = await db.ReceivedLogs.Where(p => p.PartNoSubAssy == partNumber.PartNoSubAssy)
                .Where(t => t.TimeStamp == partNumber.TimeStamp).ToListAsync();
            if (existing.Count() > 0)
            {
                foreach (var item in existing)
                {
                    item.StockReceived = true;
                };
                await db.SaveChangesAsync();

            }



            var okresult = new StatusModel()
            {
                Status = "ok",
                Detail = "",
            };
            return Ok(okresult);
        }


        [HttpPost("critical_smart_card_error_sub_assy")]
        public ActionResult Critical_smart_card_error_sub_assy([FromBody] AbnormalReturn partNumber)
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
