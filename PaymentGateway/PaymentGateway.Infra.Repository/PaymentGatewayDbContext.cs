using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Infra.Repository
{
    public partial class PaymentGatewayDbContext : DbContext
    {
        public PaymentGatewayDbContext(DbContextOptions<PaymentGatewayDbContext> options) : base(options)
        {
            
        }

        public PaymentGatewayDbContext()
        {
            
        }

        //TODO
        public virtual DbSet<Transaction> Transactions { get; set; }
    }
}
