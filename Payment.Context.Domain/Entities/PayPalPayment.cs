using Payment.Context.Domain.ValueObjects;
namespace Payment.Context.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string transactionCode, DateTime payedDate, DateTime expireDate, decimal total, decimal totalPayed, Address address, Document document, string payer, Email email) 
            :base( payedDate,  expireDate,  total,  totalPayed,  address,  document,  payer,  email)
        {
            TransactionCode = transactionCode;
        }
        public string TransactionCode { get; private set; }

    }
}
