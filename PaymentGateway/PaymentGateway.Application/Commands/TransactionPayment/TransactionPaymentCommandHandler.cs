using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentGateway.Application.Commands.BankPayment;
using PaymentGateway.Domain;

namespace PaymentGateway.Application.Commands.TransactionPayment
{
    public class TransactionPaymentCommandHandler : IRequestHandler<TransactionPaymentCommand, TransactionResponse>
    {
        private readonly IMediator _mediator;
        private readonly ITransactionRepository _repository;

        public TransactionPaymentCommandHandler(IMediator mediator, ITransactionRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<TransactionResponse> Handle(TransactionPaymentCommand request, CancellationToken cancellationToken)
        {
            var bankPaymentCommand = new BankPaymentCommand(request.Bank, request.CardInfo, request.Amount);

            var bankPaymentResponse = await _mediator.Send(bankPaymentCommand, cancellationToken);

            if (bankPaymentResponse.IsSuccess)
            {
                
                var transaction = request.ToDomain();
                var newEntity = await _repository.CreateAsync(transaction, cancellationToken);
                return new TransactionResponse(bankPaymentResponse.IsSuccess, newEntity.Id, string.Empty);
            }

            return new TransactionResponse(false, Guid.Empty, bankPaymentResponse.Message);
        }
    }
}
