using Microsoft.AspNetCore.Mvc;
using Payment.Models;
using Payment.Processing.Implementations;

namespace FlatRockTech.OnlineMarketWebAPI.Controllers
{
    public class PaymentController : ControllerBase
    {
        [HttpPost]
        [Route("Pay")]
        public async Task<dynamic> Pay(PaymentModel model)
        {
            return await MakePayment.PayAsync(model.CardNumber, model.Month, model.Year, model.CVC, model.Value);
        }
    }
}
