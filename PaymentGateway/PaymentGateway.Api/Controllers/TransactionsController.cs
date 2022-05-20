using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentGateway.Application.Commands.TransactionPayment;
using PaymentGateway.Application.Queries.Transaction;

namespace PaymentGateway.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;


        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ILogger<TransactionsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Transaction")]
        public async Task<IActionResult> ProcessPayment([FromBody] TransactionPaymentCommand paymentCommand)
        {
            if (paymentCommand.CardInfo == null && paymentCommand.CardId == Guid.Empty)
                return BadRequest(new ErrorDetail((int)HttpStatusCode.BadRequest, "No info for card and card Id"));

            var result = await _mediator.Send(paymentCommand, CancellationToken.None);

            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(new ErrorDetail((int)HttpStatusCode.BadRequest, result.Message));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayments(Guid merchantId)
        {
            if(merchantId == Guid.Empty)
                return BadRequest(new ErrorDetail((int)HttpStatusCode.BadRequest, "Merchant id must not be empty"));

            var query = new GetAllTransactionsQuery(merchantId);
            var results = await _mediator.Send(query, CancellationToken.None);

            return Ok(results);
        }

        [HttpGet]
        [Route("Transaction")]
        public async Task<IActionResult> GetPayment(Guid transactionId)
        {
            if (transactionId == Guid.Empty)
                return BadRequest(new ErrorDetail((int)HttpStatusCode.BadRequest, "Transaction id must not be empty"));

            var query = new GetTransactionQuery(transactionId);
            var result = await _mediator.Send(query, CancellationToken.None);

            return Ok(result);
        }

        public record ErrorDetail(int StatusCode, string Message);
    }
}
