using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace PaymentGateway.Bank.Mock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankPaymentController : ControllerBase
    {

        private readonly ILogger<BankPaymentController> _logger;

        public BankPaymentController(ILogger<BankPaymentController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("transactions", Name = "ProcessPayment")]
        public IActionResult ProcessPayment([FromForm] PaymentInfo paymentInfo)
        {
            if (paymentInfo.Amount < 0)
                return BadRequest(new BankResponse(Guid.Empty, false, "Amount musst be positive"));

            if(paymentInfo.CurrencyCode.Length != 3)
                return NotFound(new BankResponse(Guid.Empty, false, "Bad Cvv"));

            if(string.IsNullOrEmpty(paymentInfo.CardInfo.CardNumber))
                return NotFound(new BankResponse(Guid.Empty, false, "card number is empty"));

            return Ok(new BankResponse(Guid.NewGuid(), true, "OK"));
        }
    }
}
